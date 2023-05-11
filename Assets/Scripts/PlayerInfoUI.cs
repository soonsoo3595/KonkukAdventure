using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerInfoUI : MonoBehaviour
{
    public Text title;
    public Text grades;
    public Text kuPoint;
    public Text semester;

    Button toggleBtn;
    bool isFolded = false;

    void Awake()
    {
        toggleBtn = GetComponentInChildren<Button>();
        toggleBtn.onClick.AddListener(Click);
    }

    void Start()
    {
        grades.text = $"현재 학점 : {DataMgr.player.grade}";
        kuPoint.text = $"KU 포인트 : {DataMgr.player.KUPointReserve}";
        semester.text = $"진행 학기 : {DataMgr.player.semester}";
    }

    void Update()
    {
        
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
        grades.transform.parent.transform.DOScaleY(0f, 1f);
    }

    public void UnFold()
    {
        grades.transform.parent.transform.DOScaleY(1f, 1f);
    }
}
