using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LectureDataSet : MonoBehaviour
{
    public delegate void LectureStudyChain(LectureData lectureData);
    public static event LectureStudyChain LectureStudy;

    //강의들의 정보를 넣는 리스트
    [SerializeField] public List<LectureData> lectureData;
    //강의명을 세팅해줄 오브젝트들이 있는 위치
    [SerializeField] GameObject dir;
    //강의명을 세팅해줄 오브젝튿들이 들어갈 배열
    [SerializeField]Text[] lectureList;

    //강의 이름 세팅 메서드
    #region 강의명 세팅 및 강의 데이터 받아오기
    public void SetLectureText(List<LectureData> lectureDatas)
    {
        //강의 데이터를 업데이트
        lectureData = lectureDatas;
        //셀 내부의 강의 이름 텍스트 오브젝트들 가져오기
        lectureList = dir.GetComponentsInChildren<Text>();

        //가져온 오브젝트의 이름들 세팅
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
