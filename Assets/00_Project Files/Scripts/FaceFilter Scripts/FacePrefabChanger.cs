using UnityEngine;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class FacePrefabChanger : MonoBehaviour
{
    public SimpleScrollSnap simpleScrollSnap;
    public ARFaceManager arFaceManager;
    public GameObject[] facePrefabs; // Directly drag your face prefabs here in the inspector

    private List<GameObject> instantiatedFaceFilters = new List<GameObject>();

    private void Start()
    {
        simpleScrollSnap.OnPanelCentered.AddListener((previousPanelIndex, newPanelIndex) => { ChangeFacePrefab(newPanelIndex); });
    }

    private void ChangeFacePrefab(int newPanelIndex)
    {
        // Deactivate previous face filters
        foreach (GameObject faceFilter in instantiatedFaceFilters)
        {
            Destroy(faceFilter);
        }
        instantiatedFaceFilters.Clear();

        // Instantiate the new face filter
        if (newPanelIndex >= 0 && newPanelIndex < facePrefabs.Length)
        {
            GameObject newFaceFilterPrefab = facePrefabs[newPanelIndex];
            foreach (ARFace face in arFaceManager.trackables)
            {
                GameObject instantiatedFilter = Instantiate(newFaceFilterPrefab, face.transform);
                instantiatedFaceFilters.Add(instantiatedFilter);
            }
        }
    }
}
