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

    public Action renewalPopup;

    void Awake()
    {
        instance = this;
        DataMgr.LoadData();

        LectureUI.SetActive(false);
        StoreUI.SetActive(false);
    }

    void Start()
    {
        Debug.Log(DataMgr.quizs.data[1].options[2]);
        Debug.Log(DataMgr.quizs.data[1].question);
    }

    private void Update()
    {
        if(DataMgr.player.isSemesterOver)
        {
            if(Input.GetKeyUp(KeyCode.N)) 
            {
                SemesterOver();
            }
        }

        if(Input.GetKeyUp(KeyCode.P))
        {
            DetailInfoUI.SetActive(!DetailInfoUI.activeSelf);
        }
    }

    public void SemesterOver()
    {
        SemesterOverUI.SetActive(true);
    }
}
