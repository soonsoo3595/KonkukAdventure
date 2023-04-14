using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeLectureInfo : MonoBehaviour
{
    LectureData lectureData;
    [SerializeField] private Text nameSpace;

    void Start()
    {
        this.gameObject.SetActive(false);
        LectureDataSet.LectureStudy += Active;
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
        List<int> buildingRecord = DataMgr.BuildingRecord;
        int buildingNum = Portal.portal.BuildNum;

        if (buildingRecord == null) DataMgr.BuildingRecord.Add(buildingNum);
        else
        {
            for(int i = 0; i < buildingRecord.Count; i++)
            {
                if (buildingRecord[i].Equals(buildingNum)) break;
                else if (i.Equals(buildingRecord.Count - 1)) DataMgr.BuildingRecord.Add(buildingNum);
            }
        }
        DataMgr.LectureRecord.Add(lectureData);
    }
}
