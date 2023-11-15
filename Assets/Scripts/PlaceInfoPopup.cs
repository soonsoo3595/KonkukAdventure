using Ricimi;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaceInfoPopup : MonoBehaviour
{
    public PlaceInfo[] places;

    public GameObject studyBtn, buyBtn, quizBtn;
    public TextMeshProUGUI placeName, description;
    public Image placeImage;

    private int placeNum;

    private void Start()
    {
        studyBtn.GetComponent<CleanButton>().onClick.AddListener(ActivatePopup);
        buyBtn.GetComponent<CleanButton>().onClick.AddListener(ActivatePopup);
        quizBtn.GetComponent<CleanButton>().onClick.AddListener(ActivatePopup);
    }

    public void SetPopup(int placeNum)
    {

        this.placeNum = placeNum;

        studyBtn.SetActive(false); buyBtn.SetActive(false); quizBtn.SetActive(false);
        ActivateBtn();

        placeName.text = $"이곳은 {places[placeNum - 1].placeName} 입니다";
        description.text = places[placeNum - 1].placeDescription;
        placeImage.sprite = places[placeNum - 1].placeImage;

    }    

    public void ActivateBtn()
    {
        switch (placeNum)
        {
            //강의 건물 진입
            case 2:
            case 3:
            case 4:
            case 5:
            case 12:
            case 15:
            case 17:
            case 18:
            case 19:
            case 21:
            case 22:
            case 23:
                studyBtn.SetActive(true); buyBtn.SetActive(false); quizBtn.SetActive(false);
                break;
            //상점 해제
            case 20:
                studyBtn.SetActive(false); buyBtn.SetActive(true); quizBtn.SetActive(false);
                break;
            //퀴즈 이벤트 해제
            case 32:
            case 33:
            case 34:
                studyBtn.SetActive(false); buyBtn.SetActive(false); quizBtn.SetActive(true);
                break;
        }
    }

    public void ActivatePopup()
    {
        PopupMgr.instance.ClosePopup(PopupMgr.instance.placeInfoPopup);
        Portal.portal.ActivatePopup(placeNum);
        if (StoryManager.storyManager.storyState.Equals(4))
        {
            StoryManager.storyManager.StoryState_4();
        }
    }
}
