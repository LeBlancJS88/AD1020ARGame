using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class FacePrefabChanger : MonoBehaviour
{
    public ARFaceManager arFaceManager;
    private List<GameObject> instantiatedFaceFilters = new List<GameObject>();

    // Call this method from your button press events
    public void ChangeFacePrefab(GameObject newFaceFilterPrefab)
    {
        // Deactivate and destroy previous face filters
        foreach (GameObject faceFilter in instantiatedFaceFilters)
        {
            Destroy(faceFilter);
        }
        instantiatedFaceFilters.Clear();

        // Check if there are any faces to attach the filter to
        if (arFaceManager.trackables.count > 0)
        {
            foreach (ARFace face in arFaceManager.trackables)
            {
                // Instantiate the new face filter as a child of the ARFace
                GameObject instantiatedFilter = Instantiate(newFaceFilterPrefab, face.transform);
                instantiatedFilter.transform.localPosition = Vector3.zero;
                instantiatedFilter.transform.localRotation = Quaternion.identity;
                instantiatedFilter.transform.localScale = Vector3.one;

                instantiatedFaceFilters.Add(instantiatedFilter);
            }
        }
        else
        {
            Debug.LogWarning("No ARFaces detected.");
        }
    }
}
