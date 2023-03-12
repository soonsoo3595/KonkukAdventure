using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandArea : MonoBehaviour
{
    public RectTransform uiElement;
    public float expandedSize = 200f;
    public float expandTime = 1f;

    private bool isExpanded = false;

    public void Expand()
    {
        if (isExpanded)
        {
            StartCoroutine(SmoothResize(uiElement, uiElement.sizeDelta.y, uiElement.sizeDelta.y - expandedSize, expandTime));
            isExpanded = false;
        }
        else
        {
            StartCoroutine(SmoothResize(uiElement, uiElement.sizeDelta.y, uiElement.sizeDelta.y + expandedSize, expandTime));
            isExpanded = true;
        }
    }

    IEnumerator SmoothResize(RectTransform rt, float startSize, float endSize, float time)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / time;
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Mathf.Lerp(startSize, endSize, t));
            yield return null;
        }
    }
}
