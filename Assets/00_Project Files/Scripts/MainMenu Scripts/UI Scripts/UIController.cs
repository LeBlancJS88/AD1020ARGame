using UnityEngine;

public class UIController : MonoBehaviour
{
    // Function to control the visibility of the GameObject
    public void SetVisibility(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }
}