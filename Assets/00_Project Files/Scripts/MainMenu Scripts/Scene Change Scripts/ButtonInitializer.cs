using UnityEngine;
using UnityEngine.UI;

public class ButtonInitializer : MonoBehaviour
{
    public Button backButton;
    public Button homeButton;

    void Start()
    {
        NavigationManager navigationManager = FindObjectOfType<NavigationManager>();
        if (navigationManager == null)
        {
            Debug.LogError("NavigationManager is not found in the scene.");
            return;
        }

        if (backButton != null)
            backButton.onClick.AddListener(navigationManager.LoadLastScene);
        else
            Debug.LogError("BackButton is not assigned.");

        if (homeButton != null)
            homeButton.onClick.AddListener(navigationManager.LoadMainMenu);
        else
            Debug.LogError("HomeButton is not assigned.");
    }
}
