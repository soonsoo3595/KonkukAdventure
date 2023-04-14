using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LectureDataSet : MonoBehaviour
{
    public delegate void LectureStudyChain(LectureData lectureData);
    public static event LectureStudyChain LectureStudy;

    //���ǵ��� ������ �ִ� ����Ʈ
    [SerializeField] public List<LectureData> lectureData;
    //���Ǹ��� �������� ������Ʈ���� �ִ� ��ġ
    [SerializeField] GameObject dir;
    //���Ǹ��� �������� ������Ʊ���� �� �迭
    [SerializeField]Text[] lectureList;

    //���� �̸� ���� �޼���
    #region ���Ǹ� ���� �� ���� ������ �޾ƿ���
    public void SetLectureText(List<LectureData> lectureDatas)
    {
        //���� �����͸� ������Ʈ
        lectureData = lectureDatas;
        //�� ������ ���� �̸� �ؽ�Ʈ ������Ʈ�� ��������
        lectureList = dir.GetComponentsInChildren<Text>();

        //������ ������Ʈ�� �̸��� ����
        for (int i = 0; i < lectureList.Length; i++)
        {
            lectureList[i].text = lectureDatas[i].name;
        }
    }
    #endregion 

    public void Active1()
    {
        LectureStudy(lectureData[0]);
    }
    public void Active2()
    {
        LectureStudy(lectureData[1]);
    }
    public void Active3()
    {
        LectureStudy(lectureData[2]);
    }
    public void Active4()
    {
        LectureStudy(lectureData[3]);
    }
}
