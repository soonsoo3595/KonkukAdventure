using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysInit : MonoBehaviour
{
    Vector3 objectPosition;

    private void OnEnable()
    {
        objectPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    private void OnDisable()
    {
        GetComponent<RectTransform>().anchoredPosition = objectPosition;
    }
}
