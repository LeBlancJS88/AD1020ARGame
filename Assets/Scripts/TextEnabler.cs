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
        yield return new WaitForSeconds(3f);

        foreach (TMP_Text textElement in textElements)
        {
            if (textElement != null)
            {
                textElement.gameObject.SetActive(true); 
                yield return new WaitForSeconds(3f);
            }
        }
    }
}