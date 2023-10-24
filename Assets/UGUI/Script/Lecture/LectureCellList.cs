using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LectureCellList : MonoBehaviour
{
    [SerializeField] private GameObject activePart;
    [SerializeField] private GameObject lectureList;
    [SerializeField] private LectureCellButton[] lectures;

    private void Awake()
    {
        LectureDataSet.LectureStudy += LectureCellDataSet;
        activePart.SetActive(false);
    }

    private void LectureCellDataSet(List<LectureData> lectureDatas)
    {
        activePart.SetActive(true);
        lectures = lectureList.GetComponentsInChildren<LectureCellButton>();
        for(int i = 0; i < lectures.Length; i++)
        {
            lectures[i].lectureData = lectureDatas[i];
            lectures[i].GetComponentInChildren<TMP_Text>().text = lectureDatas[i].name;
        }
    }
    //초기화
    private void OnDisable()
    {
        activePart.SetActive(false);
    }
}
