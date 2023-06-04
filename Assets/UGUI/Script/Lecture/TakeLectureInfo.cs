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
        LectureCell.SetLecture += Active;
        buildingRecord = DataMgr.BuildingRecord;
        this.gameObject.SetActive(false);
    }

    void Active(LectureData lectureData)
    {
        this.gameObject.SetActive(true);
        SetLectureInfo(lectureData);
        SetLectureName(lectureData.name);
    }

    void SetLectureInfo(LectureData lectureData)
    {
        this.lectureData = lectureData;
    }

    void SetLectureName(string name)
    {
        InfoSpace.text = name;
    }

     public void ClickStudyButton()
    {
        if (DataMgr.player.creditReserve + lectureData.course_credit > DataMgr.player.creditLimit)
        {
            Debug.Log("더이상 강의를 수강할 수 없습니다");
            PopupMgr.instance.ClosePopup(selectStudyPopup);
            PopupMgr.instance.OpenPopup(semesterOverPopup);
        }
        else
        {
            //학점 반영
            DataMgr.record.totalCredit += lectureData.course_credit;
            DataMgr.player.creditReserve = ReflectionData();
            //Ku포인트 반영
            DataMgr.record.totalKupoint += lectureData.KU_point;
            DataMgr.player.KUPointReserve += lectureData.KU_point;

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
        return DataMgr.player.creditReserve + lectureData.course_credit;
    }

    //닫으면 설명창 초기화
    private void OnDisable()
    {
        InfoSpace.text = "";
        this.gameObject.SetActive(false);
    }
}
