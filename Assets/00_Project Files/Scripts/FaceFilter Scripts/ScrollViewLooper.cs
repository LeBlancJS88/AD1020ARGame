using UnityEngine;
using UnityEngine.UI;

public class ScrollViewLooper : MonoBehaviour
{
    [SerializeField] private RectTransform contentTransform;
    [SerializeField] private RectTransform[] filterButtonTransforms;
    [SerializeField] private HorizontalLayoutGroup horizontalLayoutGroup;

    void Update()
    {
        LoopContent();
    }

    private void LoopContent()
    {
        float itemWidthPlusSpacing = filterButtonTransforms[0].rect.width + horizontalLayoutGroup.spacing;
        if (contentTransform.localPosition.x > 0)
        {
            contentTransform.localPosition -= new Vector3(filterButtonTransforms.Length * itemWidthPlusSpacing, 0, 0);
        }
        else if (contentTransform.localPosition.x < -filterButtonTransforms.Length * itemWidthPlusSpacing)
        {
            contentTransform.localPosition += new Vector3(filterButtonTransforms.Length * itemWidthPlusSpacing, 0, 0);
        }
    }
}