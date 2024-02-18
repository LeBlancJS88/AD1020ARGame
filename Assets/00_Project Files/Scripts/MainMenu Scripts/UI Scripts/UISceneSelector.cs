using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UISceneSelector : MonoBehaviour
{
    public GameObject[] scenePanels; // The scene panel GameObjects
    public int[] sceneBuildIndices; // Array to map panel indices to scene build indices
    public Color selectedColor = Color.yellow; // The color for the selected panel
    public Color defaultColor = Color.black; // The default color for non-selected panels

    // UnityEvent for notifying when a scene is selected
    public UnityEvent OnSceneSelected; // Changed to UnityEvent with no parameters

    private Outline[] panelOutlines; // Array to hold the Outline components

    private void Awake()
    {
        panelOutlines = new Outline[scenePanels.Length];
        for (int i = 0; i < scenePanels.Length; i++)
        {
            panelOutlines[i] = scenePanels[i].GetComponent<Outline>();
        }
    }

    private void Start()
    {
        ResetPanelOutlines();
    }

    public void SelectScene(int panelIndex)
    {
        Debug.Log("Panel selected: " + panelIndex);
        SceneLoader.sceneToLoad = sceneBuildIndices[panelIndex]; // Directly set the static property
        Debug.Log("Scene to load: " + SceneLoader.sceneToLoad);

        ResetPanelOutlines();
        panelOutlines[panelIndex].effectColor = selectedColor;

        OnSceneSelected.Invoke(); // Invoke the event without passing a parameter
    }

    private void ResetPanelOutlines()
    {
        foreach (var outline in panelOutlines)
        {
            if (outline != null)
                outline.effectColor = defaultColor;
        }
    }
}
