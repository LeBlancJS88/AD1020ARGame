using UnityEngine;

public class FancyFilterButton : MonoBehaviour, IFaceFilterButton
{
    public GameObject faceFilterPrefab;
    private FacePrefabChanger facePrefabChanger;

    private void Start()
    {
        facePrefabChanger = FindObjectOfType<FacePrefabChanger>(); // Find and store a reference to the FacePrefabChanger script
    }

    public void ActivateFaceFilter()
    {
        facePrefabChanger.ChangeFacePrefab(faceFilterPrefab);
    }

    public void OnButtonPressed()
    {
        ActivateFaceFilter();
    }
}
