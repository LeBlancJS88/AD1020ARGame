using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static int sceneToLoad = -1;

    private NavigationManager navigationManager;

    void Start()
    {
        navigationManager = FindObjectOfType<NavigationManager>();
        if (navigationManager == null)
        {
            Debug.LogError("NavigationManager was not found in the scene.");
        }
    }

    public void SetSceneToLoad()
    {
        // This method now uses the static property directly
        Debug.Log("Setting scene to load: " + sceneToLoad);
    }

    public void LoadScene()
    {
        if (sceneToLoad >= 0)
        {
            // Save current scene index before loading a new scene
            navigationManager.SaveCurrentSceneIndex();

            Debug.Log("Loading scene with index: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Attempted to load a scene but no scene was set to load.");
        }
    }
}
