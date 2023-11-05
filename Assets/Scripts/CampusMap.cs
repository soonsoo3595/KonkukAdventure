using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CampusMap : MonoBehaviour
{
    public GameObject[] buildingPos;
    public GameObject popup;
    public Image blind;
    public CharacterController controller;
    public TextMeshProUGUI buildNameTxt;
    public Button yesBtn, noBtn;

    private int building;

    void Start()
    {
        yesBtn.onClick.AddListener(Teleport);    
        noBtn.onClick.AddListener(ClosePopup);
    }


    public void OpenPopup(int buildingNum)
    {
        popup.SetActive(true);
        building = buildingNum;

        string buildingName = DataMgr.Buildings.data[(int)building - 1].name;
        buildNameTxt.text = $"{buildingName}으로 이동할까요?";
    }

    public void ClosePopup() => popup.SetActive(false);

    public void Teleport()
    {
        popup.SetActive(false);

        controller.enabled = false;
        controller.transform.position = buildingPos[building - 1].transform.position;
        controller.enabled = true;

    }

}
