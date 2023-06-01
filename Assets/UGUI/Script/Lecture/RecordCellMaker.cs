using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordCellMaker : MonoBehaviour
{
    [Header("Record Area Inspector")]
    [SerializeField] private GameObject recordCell;

    [SerializeField] private Text[] recordNames;
    private List<LectureData> lectureRecords;

    public void MakeCell()
    {
        //강의 기록 가져 올 리스트 초기화
        lectureRecords = new List<LectureData>();
        lectureRecords = DataMgr.LectureRecord;

        //기록 크기 미리 받아오기
        int listSize = lectureRecords.Count;
        int childCout = this.transform.childCount;

        //강의 기록 크기만큼 인스턴스
        if (childCout < listSize - 1)
        {
            for (; childCout < listSize; childCout++)
            {
                Instantiate(recordCell, this.transform);
            }
        }
        else if (listSize == 1 && childCout!=1) Instantiate(recordCell, this.transform);

        //인스턴스 된 자식들 가져오기
        recordNames = GetComponentsInChildren<Text>();
        
        //인스턴스 된 오브젝트 텍스트 설정
        for(int i = 0; i < listSize; i++)
        {
            recordNames[i].text = lectureRecords[i].name;
        }
    }
}
