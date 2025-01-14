using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text credit;
    public TMP_Text kuPoint;
    public TMP_Text semester;

    Button toggleBtn;
    bool isFolded = false;

    void Awake()
    {
        toggleBtn = GetComponentInChildren<Button>();
        toggleBtn.onClick.AddListener(Click);
    }

    void Start()
    {
        GameManager.instance.renewalPopup += RenewalInfo;

        RenewalInfo();
    }

    public void Click()
    {
        isFolded = !isFolded;
        
        if(isFolded)
        {
            Fold();
        }
        else
        {
            UnFold();
        }
    }

    public void Fold()
    {
        credit.transform.parent.transform.DOScaleY(0f, 1f);
    }

    public void UnFold()
    {
        credit.transform.parent.transform.DOScaleY(1f, 1f);
    }

    public void RenewalInfo()
    {
        title.text = DataMgr.Player.userName;
        credit.text = $"이번학기 <color=#2BFF00>{DataMgr.Player.creditReserve}</color> 학점 수강";
        kuPoint.text = $"{DataMgr.Player.KUPointReserve} Point";
        semester.text = $"{DataMgr.Player.grade} 학년 {((DataMgr.Player.semester%2).Equals(1) ? 1 : 2)} 학기";
    }
}
