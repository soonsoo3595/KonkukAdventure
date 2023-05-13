using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject LectureUI;

    void Awake()
    {
        instance = this;

        DataMgr.LoadData();
        //selectUi.SetActive(false);
    }

    void Start()
    {
        Debug.Log(DataMgr.Item1.data[0].isPurchase);
    }

}
