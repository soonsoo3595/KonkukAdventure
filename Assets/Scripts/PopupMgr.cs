using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMgr : MonoBehaviour
{
    public Popup semesterPopup;
    public Popup detailInfoPopup;

    private LinkedList<Popup> activePopupList;
    private List<Popup> allPopupList;

    private void Awake()
    {
        activePopupList = new LinkedList<Popup>();
        Init();
        InitCloseAll();
    }

    
    public void Init()
    {
        allPopupList = new List<Popup>()
        {
            semesterPopup, detailInfoPopup
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
        foreach(var popup in allPopupList)
        {
            popup.transform.SetAsFirstSibling();
        }
    }
}
