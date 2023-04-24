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
        //���� ��� ���� �� ����Ʈ �ʱ�ȭ
        lectureRecords = new List<LectureData>();
        lectureRecords = DataMgr.LectureRecord;

        //��� ũ�� �̸� �޾ƿ���
        int listSize = lectureRecords.Count;
        int childCout = this.transform.childCount;

        //���� ��� ũ�⸸ŭ �ν��Ͻ�
        if (childCout < listSize - 1)
        {
            for (; childCout < listSize; childCout++)
            {
                Instantiate(recordCell, this.transform);
            }
        }
        else if (listSize == 1 && childCout!=1) Instantiate(recordCell, this.transform);

        //�ν��Ͻ� �� �ڽĵ� ��������
        recordNames = GetComponentsInChildren<Text>();
        
        //�ν��Ͻ� �� ������Ʈ �ؽ�Ʈ ����
        for(int i = 0; i < listSize; i++)
        {
            recordNames[i].text = lectureRecords[i].name;
        }
    }
}
