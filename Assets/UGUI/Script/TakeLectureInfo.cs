using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeLectureInfo : MonoBehaviour
{
    LectureData lectureData;
    [SerializeField] private Text nameSpace;
    List<int> buildingRecord;

    void Start()
    {
        this.gameObject.SetActive(false);
        LectureDataSet.LectureStudy += Active;
        buildingRecord = DataMgr.BuildingRecord;
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
        nameSpace.text = name;
    }

     public void ClickStudyButton()
    {
        Debug.Log(DataMgr.player.userID);

        if (ReflectionData() > DataMgr.player.creditLimit) Debug.Log(ReflectionData() + "더이상 강의를 수강할 수 없습니다");
        else
        {
            //
            DataMgr.player.creditReserve = ReflectionData();
            Debug.Log(DataMgr.player.creditReserve + " 학점");
        }
    }

    // (현재 학점에 선택한 강의의 학점이 더해진것)을 리턴하는 메서드
    // 현재 이 코드는 학점 제한으로 인해 선택한 과목을 수강 할 수 없음에도 기록을 하고있다.
    // 따라서 수정 필요
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
}
