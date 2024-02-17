using System.Collections;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight; // Reference to the directional light

    private void Start()
    {
        if (directionalLight == null)
        {
            Debug.LogError("Directional Light is not assigned in the inspector.");
            return;
        }
        StartCoroutine(RandomizeLightColor());
    }

    private IEnumerator RandomizeLightColor()
    {
        while (true) // Infinite loop to keep changing the light's color
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second

            // Generate a random color and apply it to the directional light
            Color randomColor = new Color(
                Random.Range(0f, 1f), // Random Red
                Random.Range(0f, 1f), // Random Green
                Random.Range(0f, 1f)  // Random Blue
            );
            directionalLight.color = randomColor;
        }
    }
}