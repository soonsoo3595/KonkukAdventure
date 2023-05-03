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
        Debug.Log(DataMgr.player.data.UserID);
        Debug.Log(DataMgr.player.data.grade);
        Debug.Log(DataMgr.player.data.creditLimit);
    }
}
