using UnityEngine;
using TMPro;  

public class DisplayAppVersion : MonoBehaviour
{
    private TextMeshProUGUI versionText;

    void Start()
    {
        versionText = GetComponent<TextMeshProUGUI>();
        versionText.text = "Version: " + Application.version;
    }
}
