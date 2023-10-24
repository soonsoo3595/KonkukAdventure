using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LectureCellButton : MonoBehaviour
{
    //강의 버튼 누르면 설명 나오면서 
    //강의 데이터 전송
    public delegate void LectureButtonChain(LectureData lectureData);
    public static event LectureButtonChain ClickLecture;

    [SerializeField] internal LectureData lectureData;
    public void OnClickName()
    {
        ClickLecture(lectureData);
    }
}
