using UnityEngine;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class FacePrefabChanger : MonoBehaviour
{
    public SimpleScrollSnap simpleScrollSnap;
    public ARFaceManager arFaceManager;
    public GameObject[] facePrefabs;

    // List to keep track of all instantiated face filter GameObjects
    private List<GameObject> instantiatedFaceFilters = new List<GameObject>();

    private void Start()
    {
        simpleScrollSnap.OnPanelSelected.AddListener(ChangeFacePrefab);
    }

    private void ChangeFacePrefab(int panelIndex)
    {
        // Deactivate all current face filter GameObjects
        foreach (GameObject faceFilter in instantiatedFaceFilters)
        {
            faceFilter.SetActive(false); // Or Destroy(faceFilter) if you prefer
        }
        instantiatedFaceFilters.Clear(); // Clear the list

        // Instantiate and set up the new face filter GameObjects
        if (panelIndex >= 0 && panelIndex < facePrefabs.Length)
        {
            GameObject newFaceFilterPrefab = facePrefabs[panelIndex];
            foreach (ARFace face in arFaceManager.trackables)
            {
                GameObject instantiatedFilter = Instantiate(newFaceFilterPrefab, face.transform);
                instantiatedFilter.transform.localPosition = Vector3.zero;
                instantiatedFilter.transform.localRotation = Quaternion.identity;
                instantiatedFilter.transform.localScale = Vector3.one;
                instantiatedFaceFilters.Add(instantiatedFilter); // Add to the list
            }
        }
    }
}


    //public void ChangeFacePrefab(int panelIndex)
    //{
    //    Debug.Log("Panel selected: " + panelIndex);

    //    // Ensure panelIndex is within bounds of the facePrefabs array
    //    if (panelIndex >= 0 && panelIndex < facePrefabs.Length)
    //    {
    //        // Retrieve the new prefab GameObject
    //        GameObject newFacePrefab = facePrefabs[panelIndex];

    //        // Check if the new prefab has a MeshRenderer and get its material
    //        Material newFaceMaterial = null;
    //        MeshRenderer prefabRenderer = newFacePrefab.GetComponent<MeshRenderer>();
    //        if (prefabRenderer != null)
    //        {
    //            newFaceMaterial = prefabRenderer.sharedMaterial;
    //        }
    //        else
    //        {
    //            Debug.LogError("New face prefab does not have a MeshRenderer component.");
    //            return;
    //        }

    //        // Update the material on all tracked faces
    //        foreach (ARFace face in arFaceManager.trackables)
    //        {
    //            MeshRenderer faceRenderer = face.GetComponent<MeshRenderer>();
    //            if (faceRenderer != null)
    //            {
    //                faceRenderer.material = newFaceMaterial;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("Panel index out of bounds.");
    //    }
    //}
