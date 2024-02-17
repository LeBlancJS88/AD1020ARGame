using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UISceneSelector : MonoBehaviour
{
    public GameObject[] scenePanels; // The scene panel GameObjects
    public int[] sceneBuildIndices; // Array to map panel indices to scene build indices
    public Color selectedColor = Color.yellow; // The color for the selected panel
    public Color defaultColor = Color.black; // The default color for non-selected panels
    public UnityEvent<int> OnSceneSelected;

    private Outline[] panelOutlines; // Array to hold the Outline components

    private void Awake()
    {
        // Initialize the panelOutlines array
        panelOutlines = new Outline[scenePanels.Length];
        for (int i = 0; i < scenePanels.Length; i++)
        {
            panelOutlines[i] = scenePanels[i].GetComponent<Outline>();
        }
    }

    private void Start()
    {
        // Set all panel outlines to the default color initially
        ResetPanelOutlines();
    }

    public void SelectScene(int panelIndex)
    {
        // Reset all panel outlines to default before highlighting the selected one
        ResetPanelOutlines();

        // Highlight the selected panel
        panelOutlines[panelIndex].effectColor = selectedColor;

        // Check if the panelIndex is within the bounds of the sceneBuildIndices array
        if (panelIndex >= 0 && panelIndex < sceneBuildIndices.Length)
        {
            // Invoke the event with the correct scene build index
            OnSceneSelected.Invoke(sceneBuildIndices[panelIndex]);
        }
        else
        {
            Debug.LogError("The panel index is out of range of the scene build indices array.");
        }
    }

    // Helper method to reset all panel outlines to the default color
    private void ResetPanelOutlines()
    {
        foreach (var outline in panelOutlines)
        {
            if (outline != null)
                outline.effectColor = defaultColor;
        }
    }
}