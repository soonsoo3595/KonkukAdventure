using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysInit : MonoBehaviour
{
   [SerializeField] Vector3 objectPosition;

    private void FixedUpdate()
    {
        GetComponent<RectTransform>().SetAsLastSibling();
    }

    private void OnDisable()
    {
        GetComponent<RectTransform>().anchoredPosition = objectPosition;
    }
}
