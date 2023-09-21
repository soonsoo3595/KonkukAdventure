using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ricimi;

public class StartSceneMgr : MonoBehaviour
{
    public GameObject beforeLogin, afterLogin;
    public CleanButton loginBtn, registerBtn;

    public TMP_InputField id, passwordtxt, nametxt;

    void Start()
    {
        loginBtn.onClick.AddListener(LoginRequest);
        registerBtn.onClick.AddListener(RegisterRequest);

        PlayfabMgr.Instance.updateWindow += UpdateWindow;
    }

    public void LoginRequest()
    {
        PlayfabMgr.Instance.Login(id.text, passwordtxt.text);
    }

    public void RegisterRequest() 
    {
        PlayfabMgr.Instance.Register(id.text, passwordtxt.text, nametxt.text);
    }

    public void UpdateWindow()
    {
        if(PlayfabMgr.Instance.IsLoggined())
        {
            beforeLogin.SetActive(false);
            afterLogin.SetActive(true);
        }
        else
        {
            beforeLogin.SetActive(true);
            afterLogin.SetActive(false);
        }
    }

}
