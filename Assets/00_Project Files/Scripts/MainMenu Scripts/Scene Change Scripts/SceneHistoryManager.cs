using UnityEngine;

public class SceneHistoryManager : MonoBehaviour
{
    private int lastSceneIndex = -1; // Default or invalid index

    public void SaveSceneIndex(int sceneIndex)
    {
        lastSceneIndex = sceneIndex;
    }

    public int GetLastSceneIndex()
    {
        return lastSceneIndex;
    }
}