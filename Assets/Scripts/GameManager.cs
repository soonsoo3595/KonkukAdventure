using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject LectureUI;
    public GameObject StoreUI;

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
}
