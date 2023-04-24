using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject selectUi;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        DataMgr.LoadData();
        //selectUi.SetActive(false);
    }

    void Start()
    {
        Debug.Log(DataMgr.Buildings.data[0].name);
        Debug.Log(DataMgr.Departments.data[0].name);
        Debug.Log(DataMgr.Lectures.data[0].name);
    }
}
