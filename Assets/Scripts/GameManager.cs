using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public QuestManager questManager;

    [Header("Action 인스펙터")]
    public Action renewalPopup;
    //UI 진입으로 마우스 활성화
    public Action enteringUI;
    //UI 빠져나올때 마우스 비활성화
    public Action exitUI;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(instance);
        }

        LoadData();

    }

    void Start()
    {
        
    }

    private void Update()
    {   
        if(Input.GetKey(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Start")
            {
                ExitGame();
            }
        }
    }
    public void LoadData()
    {
        if(!Director.isDataLoad)
        {
            DataMgr.LoadData();
            Director.isDataLoad = true;
        }
    }

    public void SaveData()
    {
        DataMgr.SavePlayerData();
        Director.isDataLoad = false;
    }

    public void ExitGame()
    {
        SaveData();
        // 게임 종료 전 세이브

        Debug.Log("게임 종료");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
