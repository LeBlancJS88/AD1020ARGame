using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Face : MonoBehaviour
{
    [SerializeField] private ARCameraManager arcamera;
    [SerializeField] private TMP_Text debugtext;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private GameObject hatPrefab;
    [SerializeField] private GameObject moustachePrefab;
    private int headTopIndex = 10;
    private int upperLipIndex = 164;

    [SerializeField] private GameObject cookiePrefab;

    public ARFaceManager arFace;
    private void OnEnable() => arFace.facesChanged += OnFaceChanged;
    private void OnDisable() => arFace.facesChanged -= OnFaceChanged;

    private List<ARFace> arFaces = new List<ARFace>();

    private int mouthUpperIndex = 13;
    private int mouthLowerIndex = 14;

    private bool isMouthOpen = false;

    // Threshold for mouth opening, adjust based on your model scale
    private float mouthOpenThreshold = 0.02f;
    private int cookieCount = 0;

    // Keep track of the current cookie instances per face
    private Dictionary<ARFace, GameObject> faceToCookieMap = new Dictionary<ARFace, GameObject>();

    private void Start()
    {
        scoreText.text = cookieCount.ToString();
    }
    private void Update()
    {
        if (arcamera.currentFacingDirection == CameraFacingDirection.User)
        {
            foreach (var face in arFaces)
            {
                Vector3 lowerLipPos = face.vertices[mouthLowerIndex];
                debugtext.text = lowerLipPos.ToString("F3");

                float mouthDistance = Vector3.Distance(
                    face.vertices[mouthUpperIndex],
                    face.vertices[mouthLowerIndex]
                );

                // Check if the cookie instance exists for the current face
                GameObject cookieInstance;
                if (faceToCookieMap.TryGetValue(face, out cookieInstance))
                {
                    MeshRenderer cookieRenderer = cookieInstance.GetComponent<MeshRenderer>();

                    if (mouthDistance > mouthOpenThreshold && !isMouthOpen)
                    {
                        isMouthOpen = true;
                        // Show the cookie
                        cookieRenderer.enabled = true;
                    }
                    else if (mouthDistance <= mouthOpenThreshold && isMouthOpen)
                    {
                        isMouthOpen = false;
                        // Hide the cookie
                        cookieRenderer.enabled = false;
                        cookieCount++;
                        scoreText.text = cookieCount.ToString();
                    }
                }
            }
        }
    }

    internal void OnFaceChanged(ARFacesChangedEventArgs eventArgs)
    {
        foreach (var newFace in eventArgs.added)
        {
            arFaces.Add(newFace);
            AttachHatToHead(newFace);
            AttachMoustacheToLip(newFace);
            AttachCookieToMouth(newFace); // Now attaching the cookie here
        }

        foreach (var removedFace in eventArgs.removed)
        {
            arFaces.Remove(removedFace);
            // Additionally, remove the cookie when a face is lost
            if (faceToCookieMap.TryGetValue(removedFace, out var cookieInstance))
            {
                Destroy(cookieInstance);
                faceToCookieMap.Remove(removedFace);
            }
        }
    }

    private void AttachHatToHead(ARFace face)
    {
        Vector3 headTopPos = face.transform.TransformPoint(face.vertices[headTopIndex]);
        GameObject hatInstance = Instantiate(hatPrefab, headTopPos, Quaternion.identity);
        hatInstance.transform.parent = face.transform;
    }

    private void AttachMoustacheToLip(ARFace face)
    {
        Vector3 upperLipPos = face.transform.TransformPoint(face.vertices[upperLipIndex]);
        GameObject moustacheInstance = Instantiate(moustachePrefab, upperLipPos, Quaternion.identity);
        moustacheInstance.transform.parent = face.transform;
    }

    private void AttachCookieToMouth(ARFace face)
    {
        Vector3 mouthPos = face.transform.TransformPoint(face.vertices[mouthUpperIndex]);
        GameObject cookieInstance = Instantiate(cookiePrefab, mouthPos, Quaternion.identity);
        cookieInstance.transform.parent = face.transform;
        // Initially hide the cookie
        cookieInstance.GetComponent<MeshRenderer>().enabled = false;
        // Map the face to the cookie instance
        faceToCookieMap[face] = cookieInstance;
    }
}