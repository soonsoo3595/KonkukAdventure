using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임에서 팝업을 열고 닫을 때 이 스크립트의 OpenPopup, ClosePopup함수를 이용해서 열어야 합니다

public class PopupMgr : MonoBehaviour
{
    public LinkedList<Popup> activePopupList;  // 활성화된 팝업 리스트
    private List<Popup> allPopupList;   // 모든 팝업 리스트

    [Header("Popup")]
    public Popup semesterOverPopup;
    public Popup detailInfoPopup;
    public Popup selectStudyPopup;
    public Popup storePopup;
    public Popup dialoguePopup;
 

    public static PopupMgr instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        activePopupList = new LinkedList<Popup>();
        Init();
        InitCloseAll();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (activePopupList.Count > 0)
            {
                ClosePopup(activePopupList.First.Value);
            }
        }

        ToggleKeyDownAction(KeyCode.P, detailInfoPopup);

        if (DataMgr.Player.isSemesterOver)
        {
            ToggleKeyDownAction(KeyCode.N, semesterOverPopup);
        }
    }

    public void Init()
    {
        allPopupList = new List<Popup>()
        {
            semesterOverPopup, detailInfoPopup, selectStudyPopup, storePopup, dialoguePopup
        };

        foreach (var popup in allPopupList)
        {
            // 헤더 포커스 이벤트
            popup.OnFocus += () =>
            {
                activePopupList.Remove(popup);
                activePopupList.AddFirst(popup);
                RefreshAllPopupDepth();
            };

            // 닫기 버튼 이벤트
            popup.closeButton.onClick.AddListener(() => ClosePopup(popup));
        }
    }

    public void InitCloseAll()
    {
        foreach (var popup in allPopupList)
        {
            ClosePopup(popup);
        }
    }

    private void ToggleKeyDownAction(in KeyCode key, Popup popup)
    {
        if (Input.GetKeyDown(key))
            ToggleOpenClosePopup(popup);
    }

    private void ToggleOpenClosePopup(Popup popup)
    {
        if (!popup.gameObject.activeSelf) OpenPopup(popup);
        else ClosePopup(popup);
    }

    public void OpenPopup(Popup popup)
    {
        GameManager.instance.enteringUI();

        activePopupList.AddFirst(popup);
        popup.gameObject.SetActive(true);
        RefreshAllPopupDepth();
    }

    public void ClosePopup(Popup popup)
    {
        activePopupList.Remove(popup);
        popup.gameObject.SetActive(false);
        RefreshAllPopupDepth();

        GameManager.instance.exitUI();
    }


    private void RefreshAllPopupDepth()
    {
        foreach (var popup in activePopupList)
        {
            popup.transform.SetAsFirstSibling();
        }
    }

    public bool IsPopupActive()
    {
        if (activePopupList.Count > 0)
            return true;
        else
            return false;
    }
}
