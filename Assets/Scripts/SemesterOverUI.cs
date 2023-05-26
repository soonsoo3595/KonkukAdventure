using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SemesterOverUI : MonoBehaviour
{
    public Text title, currentTxt, nextTxt, description;
    public Button nextBtn, stayBtn;

    private void Awake()
    {
        nextBtn.onClick.AddListener(Next);
        stayBtn.onClick.AddListener(Stay);
    }

    void Start()
    {
        
    }

    private void OnEnable()
    {
        int currentSemester = DataMgr.player.semester;
        Text nextBtnTxt = nextBtn.GetComponentInChildren<Text>();

        currentTxt.text = $"  현재 학기 : {currentSemester}학기";

        if(DataMgr.IsLastSemester())
        {
            title.text = "마지막 학기가 끝났습니다";
            nextTxt.text = $"  다음 학기 : 졸업";
            description.text = "  졸업을 하시려면 왼쪽 버튼을 눌러주세요\n  아직 더 머무르고 싶으면 오른쪽 버튼을 눌러주세요\n  (N키를 눌러 언제든지 창을 다시 띄울 수 있습니다)";
            nextBtnTxt.text = "졸업하기";
        }
        else
        {
            title.text = "현재 학기가 종료 되었습니다";
            nextTxt.text = $"  다음 학기 : {currentSemester + 1}학기";
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

            DataMgr.player.semester += 1;   // 학기 설정
            DataMgr.player.grade = (DataMgr.player.semester / 2) + 1;   // 학년 설정
            DataMgr.player.creditReserve = 0;   // 학점 0점으로 돌리기

            GameManager.instance.renewalPopup();
        }

        DataMgr.player.isSemesterOver = false;
        gameObject.SetActive(false);
    }

    public void Stay()
    {
        Debug.Log("현재 학기 유지");

        DataMgr.player.isSemesterOver = true;
        gameObject.SetActive(false);
    }
}
