using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public string sceneName;    // 이동할 씬의 이름

    Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    private void Start()
    {
        btn.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {
        if(sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }    
}
