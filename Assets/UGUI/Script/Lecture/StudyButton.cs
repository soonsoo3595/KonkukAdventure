using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StudyButton : MonoBehaviour
{
    LectureData lectureData;
    [SerializeField] private TMP_Text InfoSpace;
    List<int> buildingRecord;

    [SerializeField] private GameObject completePopup;
    public Popup semesterOverPopup;
    public Popup selectStudyPopup;

    void Start()
    {
        LectureCellButton.ClickLecture += Active;
        buildingRecord = DataMgr.BuildingRecord;
    }

    void Active(LectureData lectureData)
    {
        this.gameObject.SetActive(true);
        GetLectureData(lectureData);
        SetLectureName(lectureData);
    }

    void GetLectureData(LectureData lectureData)
    {
        this.lectureData = lectureData;
    }

    void SetLectureName(LectureData name)
    {
        InfoSpace.text = $"{name.grade} 학년 과목\n획득 가능 학점: {name.course_credit}\n획득 가능 포인트: {name.KU_point}";
    }

     public void ClickStudyButton()
    {
        if (DataMgr.Player.creditReserve + lectureData.course_credit > DataMgr.Player.creditLimit)
        {
            Debug.Log("더이상 강의를 수강할 수 없습니다");
            PopupMgr.instance.ClosePopup(selectStudyPopup);
            PopupMgr.instance.OpenPopup(semesterOverPopup);
        }
        else
        {
            //학점 반영
            DataMgr.Record.totalCredit += lectureData.course_credit;
            DataMgr.Player.creditReserve = ReflectionData();
            //Ku포인트 반영
            DataMgr.Record.totalKupoint += lectureData.KU_point;
            DataMgr.Player.KUPointReserve += lectureData.KU_point;

            GameManager.instance.renewalPopup();

            completePopup.SetActive(true);
        }
    }

    // (현재 학점에 선택한 강의의 학점이 더해진것)을 리턴하는 메서드
    private int ReflectionData()
    {
        int buildingNum = Portal.portal.BuildNum;

        if (buildingRecord == null) DataMgr.BuildingRecord.Add(buildingNum);
        else
        {
            for (int i = 0; i < buildingRecord.Count; i++)
            {
                if (buildingRecord[i].Equals(buildingNum)) break;
                else if (i.Equals(buildingRecord.Count - 1)) DataMgr.BuildingRecord.Add(buildingNum);
            }
        }

        DataMgr.LectureRecord.Add(lectureData);
        return DataMgr.Player.creditReserve + lectureData.course_credit;
    }

    //닫으면 설명창 초기화
    private void OnDisable()
    {
        InfoSpace.text = "";
        this.gameObject.SetActive(false);
    }
}
