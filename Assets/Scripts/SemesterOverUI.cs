using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SemesterOverUI : MonoBehaviour
{
    Popup popup;

    public TMP_Text title, currentTxt, nextTxt;
    public Button nextBtn, stayBtn;

    private void Awake()
    {
        popup = GetComponent<Popup>();
        nextBtn.onClick.AddListener(Next);
        stayBtn.onClick.AddListener(Stay);
    }

    private void OnEnable()
    {
        int currentSemester = DataMgr.Player.semester;
        TMP_Text nextBtnTxt = nextBtn.GetComponentInChildren<TMP_Text>();

        currentTxt.text = $"현재 학기 : {currentSemester}학기";

        if(DataMgr.IsLastSemester())
        {
            title.text = "마지막 학기가 끝났습니다";
            nextTxt.text = $"다음 학기 : 졸업";
            nextBtnTxt.text = "졸업 하기";
        }
        else
        {
            title.text = "현재 학기가 종료 되었습니다";
            nextTxt.text = $"다음 학기 : {currentSemester + 1}학기";
        }

    }

    public void Next()
    {
        if(DataMgr.IsLastSemester())
        {
            // 졸업 부분
            Debug.Log("졸업");
        }
        else
        {
            Debug.Log("다음 학기로");

            DataMgr.Player.semester += 1;   // 학기 설정
            DataMgr.Player.grade = GradeCalculate(DataMgr.Player.semester);   // 학년 설정
            DataMgr.Player.creditReserve = 0;   // 학점 0점으로 돌리기

            GameManager.instance.renewalPopup();
        }

        DataMgr.Player.isSemesterOver = false;
        PopupMgr.instance.ClosePopup(popup);
    }

    public void Stay()
    {
        Debug.Log("현재 학기 유지");

        DataMgr.Player.isSemesterOver = true;
        PopupMgr.instance.ClosePopup(popup);
        this.GetComponent<Animator>().SetBool("close", true);
    }

    private int GradeCalculate(int num)
    {
        switch (num)
        {
            case 1:
            case 2: return 1;
            case 3:
            case 4: return 2;
            case 5:
            case 6: return 3;
            case 7:
            case 8: return 4;
        }
        return default;
    }
}
