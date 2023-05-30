using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMgr : MonoBehaviour
{
    private LinkedList<Popup> activePopupList;  // 활성화된 팝업 리스트
    private List<Popup> allPopupList;   // 모든 팝업 리스트

    [Header("Popup")]
    public Popup semesterOverPopup;
    public Popup detailInfoPopup;
    public Popup selectStudyPopup;
    public Popup storePopup;

    private void Awake()
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

        if (DataMgr.player.isSemesterOver)
        {
            ToggleKeyDownAction(KeyCode.N, semesterOverPopup);
        }
    }

    public void Init()
    {
        allPopupList = new List<Popup>()
        {
            semesterOverPopup, detailInfoPopup, selectStudyPopup, storePopup
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
            // popup._closeButton.onClick.AddListener(() => ClosePopup(popup));
        }
    }

    
    private void InitCloseAll()
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

    private void OpenPopup(Popup popup)
    {
        activePopupList.AddFirst(popup);
        popup.gameObject.SetActive(true);
        RefreshAllPopupDepth();
    }

    private void ClosePopup(Popup popup)
    {
        activePopupList.Remove(popup);
        popup.gameObject.SetActive(false);
        RefreshAllPopupDepth();
    }

    private void RefreshAllPopupDepth()
    {
        foreach(var popup in activePopupList)
        {
            popup.transform.SetAsFirstSibling();
        }
    }
}
