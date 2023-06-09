using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject LectureUI;
    public GameObject StoreUI;
    public GameObject SemesterOverUI;
    public GameObject DetailInfoUI;
    public GameObject DialogueUI;

    public Action renewalPopup;

    //UI 진입으로 마우스 활성화
    public Action enteringUI;
    //UI 빠져나올때 마우스 비활성화
    public Action exitUI;

    void Awake()
    {
        instance = this;
        DataMgr.LoadData();
        Debug.Log("실행");
    }
}
