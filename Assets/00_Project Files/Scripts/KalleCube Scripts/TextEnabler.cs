using System.Collections;
using TMPro;
using UnityEngine;

public class TextEnabler : MonoBehaviour
{
    [SerializeField] private TMP_Text[] textElements;

    void Start()
    {
        StartCoroutine(EnableTextElementsSequentially());
    }

    private IEnumerator EnableTextElementsSequentially()
    {
        // Initial wait before starting the sequence
        yield return new WaitForSeconds(3f); 

        // Loop through each text element by index to enable, wait, then disable
        for (int i = 0; i < textElements.Length; i++)
        {
            if (textElements[i] != null)
            {
                // Enable the current text element
                textElements[i].gameObject.SetActive(true);

                // Wait for 3 seconds after enabling
                yield return new WaitForSeconds(3f); 

                // Disable the current text element
                textElements[i].gameObject.SetActive(false);

                // If not the last element, wait for 3 seconds before proceeding to the next element
                if (i < textElements.Length - 1)
                {
                    yield return new WaitForSeconds(3f);
                }
            }
        }
    }
}
