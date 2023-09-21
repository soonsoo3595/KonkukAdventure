using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using System;
using Unity.VisualScripting;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class PlayfabMgr : MonoBehaviour
{
    private static PlayfabMgr instance;

    private string playerName = string.Empty;
    private string playerID = string.Empty;

    public static PlayfabMgr Instance { get { return instance; } }

    public Action updateWindow;
    public Action register;

    void Awake()
    {
        instance = this;
    }

    public void Login(string id, string password)
    {
        var request = new LoginWithPlayFabRequest { Username = id, Password = password };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
    }

    public void Register(string id, string password, string name)
    {
        playerName = name;  // 임시,,

        var request = new RegisterPlayFabUserRequest { Username = id, Password = password, RequireBothUsernameAndEmail = false, DisplayName = name };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
    }

    public void Logout()
    {
        PlayFabClientAPI.ForgetAllCredentials();
        updateWindow();
    }

    public bool IsLoggined() => PlayFabClientAPI.IsClientLoggedIn();

    public void GetPlayerProfile()
    {
        if(IsLoggined())
        {
            var request = new GetPlayerProfileRequest
            {
                PlayFabId = playerID,
            };

            PlayFabClientAPI.GetPlayerProfile(request, OnGetPlayerProfileSuccess, OnGetPlayerProfileFailure);
        }
    }

    public void SaveJsonToPlayfab()
    {
        PlayerData playerData = new PlayerData();
        PlayerRecordData recordData = new PlayerRecordData();

        playerData.userID = playerID;
        playerData.userName = playerName;

        recordData.userID = playerID;

        Dictionary<string, string> data = new Dictionary<string, string>();

        data.Add("PlayerData", JsonUtility.ToJson(playerData));
        data.Add("PlayerRecordData", JsonUtility.ToJson(recordData));

        SetUserData(data);
    }

    public void SetUserData(Dictionary<string, string> data)
    {
        var request = new UpdateUserDataRequest() { Data = data, Permission = UserDataPermission.Public };
        try
        {
            PlayFabClientAPI.UpdateUserData(request, (result) =>
            {
                Debug.Log("Update Player Data!");

            }, DisplayPlayfabError);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void GetUserData()
    {
        var request = new GetUserDataRequest() { PlayFabId = playerID };
        PlayFabClientAPI.GetUserData(request, (result) =>
        {
            foreach (var eachData in result.Data)
            {
                string key = eachData.Key;

                if (eachData.Key.Contains("PlayerData"))
                {
                    PlayerData player = JsonUtility.FromJson<PlayerData>(eachData.Value.Value);

                    DataMgr.Player = player;
                }
                if (eachData.Key.Contains("PlayerRecordData"))
                {
                    PlayerRecordData record = JsonUtility.FromJson<PlayerRecordData>(eachData.Value.Value);

                    DataMgr.Record = record;
                }
            }

        }, DisplayPlayfabError);
    }

    public void GetDisplayName()
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest()
        {
            PlayFabId = playerID,
            ProfileConstraints = new PlayerProfileViewConstraints()
            {
                ShowDisplayName = true
            }
        },
        (result) =>
        {
            playerName = result.PlayerProfile.DisplayName;
        },
        DisplayPlayfabError);
    }

    private void DisplayPlayfabError(PlayFabError error) => Debug.LogError("error : " + error.GenerateErrorReport());

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("로그인 성공");
        playerID = result.PlayFabId;

        GetUserData();

        updateWindow();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("회원가입 성공");
        playerID = result.PlayFabId;

        SaveJsonToPlayfab();
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogWarning("가입 실패");
        Debug.LogWarning(error.GenerateErrorReport());
    }

    private void OnGetPlayerProfileSuccess(GetPlayerProfileResult result)
    {
        Debug.Log("Player ID: " + playerID);
        
    }

    private void OnGetPlayerProfileFailure(PlayFabError error)
    {
        Debug.LogError("Error getting player profile: " + error.ErrorMessage);
    }
}
