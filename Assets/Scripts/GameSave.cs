using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSave : MonoBehaviour
{
    public Button btn;

    void Start()
    {
        btn.onClick.AddListener(SaveData);
    }

    public void SaveData()
    {
        GameManager.instance.ExitGame();
    }    
}
