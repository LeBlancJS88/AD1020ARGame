using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    // Assuming each UIController is attached to a panel GameObject
    public UIController[] panelControllers;

    private void OnEnable()
    {
        UIManager.ShowSettingsPanel += ShowSettingsPanel;
        UIManager.ShowSceneSelectionPanel += ShowSceneSelectionPanel;
        UIManager.HidePanels += HideAllPanels;
    }

    private void OnDisable()
    {
        UIManager.ShowSettingsPanel -= ShowSettingsPanel;
        UIManager.ShowSceneSelectionPanel -= ShowSceneSelectionPanel;
        UIManager.HidePanels -= HideAllPanels;
    }

    void ShowSettingsPanel()
    {
        foreach (var controller in panelControllers)
        {
                // Name matches the GameObject exactly in Unity
            if (controller.gameObject.name == "Settings Panel") 
                controller.SetVisibility(true);
            else
                controller.SetVisibility(false);
        }
    }

    void ShowSceneSelectionPanel()
    {
        foreach (var controller in panelControllers)
        {
                // Name matches the GameObject exactly in Unity
            if (controller.gameObject.name == "Scene Selection Panel")
                
                controller.SetVisibility(true);
            else
                controller.SetVisibility(false);
        }
    }

    void HideAllPanels()
    {
        foreach (var controller in panelControllers)
        {
            controller.SetVisibility(false);
        }
    }
}