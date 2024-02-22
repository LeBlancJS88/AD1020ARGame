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
        simpleScrollSnap.OnPanelCentered.AddListener((previousPanelIndex, newPanelIndex) => {ChangeFacePrefab(newPanelIndex);});
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
