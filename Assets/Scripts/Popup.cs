using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Popup : MonoBehaviour, IPointerDownHandler
{
    public event Action OnFocus;
    public Button closeButton;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        OnFocus();
    }
}
