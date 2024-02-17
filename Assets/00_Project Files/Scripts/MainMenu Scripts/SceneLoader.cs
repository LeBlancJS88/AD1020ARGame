using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int sceneToLoad = -1; // Default to an invalid scene index

    // Method to be called by the UISceneSelector when a scene is selected
    public void SetSceneToLoad(int index)
    {
        sceneToLoad = index;
    }

    // Method to be called by the Load button to load the selected scene
    public void LoadScene()
    {
        if (sceneToLoad >= 0) // Check if a valid scene has been selected
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No scene has been selected to load!");
        }
    }
}