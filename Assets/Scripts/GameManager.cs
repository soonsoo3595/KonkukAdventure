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

        LectureUI.SetActive(false);
        StoreUI.SetActive(false);
        DialogueUI.SetActive(true);
    }

    void Start()
    {
        Debug.Log(DataMgr.Dialogue.quiz[1].options[2]);
        Debug.Log(DataMgr.Dialogue.quiz[1].question);
    }

    private void Update()
    {
        

    }

    public void SemesterOver()
    {
        SemesterOverUI.SetActive(true);
    }
}
