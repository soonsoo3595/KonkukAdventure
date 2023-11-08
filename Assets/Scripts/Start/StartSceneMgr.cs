using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ricimi;

public class StartSceneMgr : MonoBehaviour
{
    public GameObject beforeLogin, afterLogin, nameInput;
    public CleanButton loginBtn, registerBtn, confirmBtn;
    public TMP_InputField[] inputFields;
    public TextMeshProUGUI descript, info;

    private CurrentTab currentTab = CurrentTab.Login;

    void Start()
    {
        loginBtn.onClick.AddListener(ClickLogin);
        registerBtn.onClick.AddListener(ClickRegister);
        confirmBtn.onClick.AddListener(Continue);

        PlayfabMgr.Instance.updateWindow += UpdateWindow;
    }

    public void LoginRequest()
    {
        PlayfabMgr.Instance.Login(inputFields[1].text, inputFields[2].text);
    }

    public void RegisterRequest() 
    {
        PlayfabMgr.Instance.Register(inputFields[1].text, inputFields[2].text, inputFields[0].text);
    }

    public void UpdateWindow()
    {
        if (PlayfabMgr.Instance.isLoginned)
        {
            if (PlayfabMgr.Instance.playerName == string.Empty)
            {
                Invoke("AfterLogin", 1f);
            }
            else
            {
                AfterLogin();
            }
        }
        else
        {
            beforeLogin.SetActive(true);
            afterLogin.SetActive(false);
        }
    }

    public void Continue()
    {
        if(currentTab == CurrentTab.Login)
        {
            LoginRequest();
        }
        else if(currentTab == CurrentTab.Register)
        {
            RegisterRequest();
        }

        EmptyText();
    }

    private void ClickLogin()
    {
        currentTab = CurrentTab.Login;
        nameInput.SetActive(false);

        EmptyText();
    }
    private void ClickRegister()
    {
        currentTab = CurrentTab.Register;
        nameInput.SetActive(true);

        EmptyText();
    }
    
    private void EmptyText()
    {
        for(int i = 0; i < inputFields.Length; i++)
        {
            inputFields[i].text = string.Empty;
        }
    }

    private void AfterLogin()
    {
        beforeLogin.SetActive(false);
        afterLogin.SetActive(true);
        UpdateDescription();
    }

    public void UpdateDescription()
    {
        descript.text = $"{PlayfabMgr.Instance.playerName}님 안녕하세요!";
    }

    
}
