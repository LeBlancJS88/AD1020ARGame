using UnityEngine;
using UnityEngine.UI;

public class ScrollViewManager : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private HorizontalLayoutGroup horizontalLayoutGroup;
    [SerializeField] private ButtonPrefabInstantiator buttonPrefabInstantiator;

    void Start()
    {
        buttonPrefabInstantiator.InstantiateButtons(scrollRect.viewport, horizontalLayoutGroup);
    }
}
