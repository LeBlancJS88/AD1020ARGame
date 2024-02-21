using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    public SceneHistoryManager sceneHistoryManager;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        // Automatically find and assign SceneHistoryManager instance
        sceneHistoryManager = FindObjectOfType<SceneHistoryManager>();

        if (sceneHistoryManager == null)
        {
            Debug.LogError("SceneHistoryManager not found in the scene. Please add it to ensure NavigationManager functions correctly.");
        }
    }

    public void SaveCurrentSceneIndex()
    {
        sceneHistoryManager.SaveSceneIndex(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLastScene()
    {
        SceneManager.LoadScene(sceneHistoryManager.GetLastSceneIndex());
    }

    public void LoadMainMenu()
    {
        // Reference to the Main Menu scene by index
        SceneManager.LoadScene(0);
    }
}