using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static int sceneToLoad = -1;

    public void SetSceneToLoad()
    {
        // This method now uses the static property directly
        Debug.Log("Setting scene to load: " + sceneToLoad);
    }

    public void LoadScene()
    {
        if (sceneToLoad >= 0)
        {
            Debug.Log("Loading scene with index: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Attempted to load a scene but no scene was set to load.");
        }
    }
}
