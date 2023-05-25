using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public delegate void StopCharactor();
    public static event StopCharactor ReStartPlayer;

    [SerializeField] private GameObject closeUI;

    public void Close()
    {
        closeUI.SetActive(false);
        ReStartPlayer();
    }
}
