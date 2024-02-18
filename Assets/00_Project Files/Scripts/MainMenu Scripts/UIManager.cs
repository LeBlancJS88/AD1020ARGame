using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static event Action ShowSettingsPanel = delegate { };
    public static event Action ShowSceneSelectionPanel = delegate { };
    public static event Action HidePanels = delegate { };

    // These methods can be called by UI button click event listeners
    public void TriggerShowSettingsPanel()
    {
        ShowSettingsPanel.Invoke();
    }

    public void TriggerShowSceneSelectionPanel()
    {
        ShowSceneSelectionPanel.Invoke();
    }

    public void TriggerHidePanels()
    {
        HidePanels.Invoke();
    }
}