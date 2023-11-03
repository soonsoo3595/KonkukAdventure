using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CampusMap : MonoBehaviour
{
    public GameObject popup;
    public TextMeshProUGUI buildNameTxt;

    public Button yesBtn, noBtn;

    void Start()
    {
        yesBtn.onClick.AddListener(Teleport);    
        noBtn.onClick.AddListener(ClosePopup);
    }


    public void OpenPopup(int buildingNum)
    {
        popup.SetActive(true);

        string buildingName = DataMgr.Buildings.data[(int)buildingNum - 1].name;
        buildNameTxt.text = $"{buildingName}으로 이동할까요?";
    }

    public void ClosePopup() => popup.SetActive(false);

    public void Teleport()
    {

    }
}
