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
        Debug.Log(DataMgr.player.data.UserID);
        if (ReflectionData() > DataMgr.player.data.creditLimit) Debug.Log(ReflectionData() + "���̻� ���Ǹ� ������ �� �����ϴ�");
        else
        {
            DataMgr.player.data.creditReserve = ReflectionData();
            Debug.Log(DataMgr.player.data.creditReserve + " ����");
        }
    }

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
        return DataMgr.player.data.creditReserve + lectureData.course_credit;
    }
}
