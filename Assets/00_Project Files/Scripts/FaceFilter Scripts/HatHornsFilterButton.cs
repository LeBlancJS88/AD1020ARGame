using UnityEngine;

public class HatHornsFilterButton : MonoBehaviour, IFaceFilterButton
{
    public GameObject faceFilterPrefab;
    private FacePrefabChanger facePrefabChanger;

    private void Start()
    {
        // Find and store a reference to the FacePrefabChanger script
        facePrefabChanger = FindObjectOfType<FacePrefabChanger>(); 
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
