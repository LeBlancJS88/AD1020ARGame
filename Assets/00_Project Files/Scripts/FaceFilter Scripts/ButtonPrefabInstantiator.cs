using UnityEngine;
using UnityEngine.UI;

public class ButtonPrefabInstantiator : MonoBehaviour
{
    [SerializeField] private RectTransform contentTransform;
    [SerializeField] private RectTransform[] filterButtonPrefabs;

    public void InstantiateButtons(RectTransform viewportTransform, HorizontalLayoutGroup layoutGroup)
    {
        int itemsToAdd = CalculateItemsToAdd(viewportTransform, layoutGroup);
        for (int i = 0; i < itemsToAdd; i++)
        {
            Instantiate(filterButtonPrefabs[i % filterButtonPrefabs.Length], contentTransform);
        }
    }

    private int CalculateItemsToAdd(RectTransform viewportTransform, HorizontalLayoutGroup layoutGroup)
    {
        return Mathf.CeilToInt(viewportTransform.rect.width / (filterButtonPrefabs[0].rect.width + layoutGroup.spacing));
    }
}