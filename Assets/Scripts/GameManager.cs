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
        //selectUi.SetActive(false);
    }

    void Start()
    {
        Debug.Log(DataMgr.Items.creditLimit[1].isPurchase);
        Debug.Log(DataMgr.Items.otherItem[1].name);
    }
}
