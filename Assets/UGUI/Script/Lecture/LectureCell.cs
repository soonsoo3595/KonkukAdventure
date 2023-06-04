using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LectureCell : MonoBehaviour
{
    //강의 버튼 누르면 설명 나오면서 
    //강의 데이터 전송
    public delegate void LectureStudyChain(LectureData lectureData);
    public static event LectureStudyChain SetLecture;

    [SerializeField] internal LectureData lectureData;
    public void onClickName()
    {
        SetLecture(lectureData);
    }
}
