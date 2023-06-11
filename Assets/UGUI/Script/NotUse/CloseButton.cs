using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject closeUI;

    public void Close()
    {
        closeUI.SetActive(false);
        GameManager.instance.exitUI();
    }
}
