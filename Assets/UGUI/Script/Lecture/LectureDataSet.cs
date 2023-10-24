using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LectureDataSet : MonoBehaviour
{
    //LectureCellList에서의 메서드 위임자
    public delegate void LectureStudyChain(List<LectureData> lectureData);
    public static event LectureStudyChain LectureStudy;

    //강의들의 정보를 넣는 리스트
    [SerializeField] internal List<LectureData> lectureData;

    public void OnClickName()
    {
        LectureStudy(lectureData);
    }
}
