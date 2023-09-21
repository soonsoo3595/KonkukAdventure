using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#region 플레이어 데이터
[System.Serializable]
public class PlayerData
{
    public string userID;
    public string userName;
    public int grade;
    public int semester;
    public int creditLimit;
    public int creditReserve;
    public int scoreReserve;
    public int KUPointReserve;
    public bool isSemesterOver;
    public bool isFirstGame;

    public PlayerData() 
    {
        userID = string.Empty;
        userName = string.Empty;
        grade = 1;
        semester = 1;
        creditLimit = 4;
        creditReserve = 0;
        scoreReserve = 0;
        KUPointReserve = 0;
        isSemesterOver = false;
        isFirstGame = false;
    }
}

public class PlayerRecordData
{
    public string userID;
    public int totalCredit;
    public int totalKupoint;
    public int graduateCredit;

    public PlayerRecordData()
    {
        userID = string.Empty;
        totalCredit = 0;
        totalKupoint = 0;
        graduateCredit = 80;
    }
}
#endregion

#region 건물 데이터
[System.Serializable]
public class BuildingData
{
    public int buildingID;
    public string name;
    public string subType;
}

[System.Serializable]
public class BuildingDataList
{
    // 이 List<BuildingData>의 변수명이 json파일에 제일 처음에 있는 이름과 같아야 함!!
    public List<BuildingData> data;
}
#endregion

#region 학과 데이터
[System.Serializable]
public class DepartmentData
{
    public int departmentID;
    public int buildingID;
    public string name;
}

[System.Serializable]
public class DepartmentDataList
{
    public List<DepartmentData> data;
}
#endregion

#region 강의 데이터
[System.Serializable]
public class LectureData
{
    public int studyID;
    public int departmentID;
    public int grade;
    public int course_credit;
    public int KU_point;
    public string name;
}

[System.Serializable]
public class LectureDataList
{
    public List<LectureData> data;
}
#endregion

#region 아이템 데이터
[System.Serializable]
public class CreditLimit
{
    public int itemID;
    public int itemTypeID;
    public string name;
    public int price;
    public int reward;
    public bool isPurchase;
    public string itemInfo;
}

[System.Serializable]
public class OtherItemData
{
    public int itemID;
    public int itemTypeID;
    public string name;
    public int price;
    public bool isPurchase;
    public string itemInfo;
}

[System.Serializable]
public class ItemDataList
{
    public List<CreditLimit> creditLimit;
    public List<OtherItemData> otherItem;
}
#endregion

#region 다이얼로그 데이터
[System.Serializable]
public class QuizData
{
    public int quizID;
    public string name;
    public string question;
    public string[] options;
    public string correct;
    public int reward;
    public bool isEnter;
}

[System.Serializable]
public class DialogueDataList
{
    public List<QuizData> quiz;
}
#endregion

public static class DataMgr
{
    #region 수강 기록 코드...
    public static List<int> BuildingRecord = new List<int>();
    public static List<LectureData> LectureRecord = new List<LectureData>();
    #endregion

    #region Json 경로
    // private static string playerJsonPath = "JSON/PlayerData";
    // private static string playerRecordJsonPath = "JSON/PlayerRecordData";
    private static string buildingJsonPath = "JSON/BuildingData";
    private static string departmentJsonPath = "JSON/DepartmentData";
    private static string lectureJsonPath = "JSON/LectureData";
    private static string itemJsonPath = "JSON/ItemData";
    private static string quizJsonPath = "JSON/DialogueData";
    #endregion

    public static PlayerData Player { get; set; }
    public static PlayerRecordData Record { get; set; }
    public static BuildingDataList Buildings { get; private set; }
    public static DepartmentDataList Departments { get; private set; }
    public static LectureDataList Lectures { get; private set; }
    public static ItemDataList Items { get; private set; }
    public static DialogueDataList Dialogue { get; private set; }

    public static void LoadData()
    {
        // TextAsset playerJson = Resources.Load<TextAsset>(playerJsonPath);
        // TextAsset playerRecordJson = Resources.Load<TextAsset>(playerRecordJsonPath);
        TextAsset buildingJson = Resources.Load<TextAsset>(buildingJsonPath);
        TextAsset departmentJson = Resources.Load<TextAsset>(departmentJsonPath);
        TextAsset lectureJson = Resources.Load<TextAsset>(lectureJsonPath);
        TextAsset itemJson = Resources.Load<TextAsset>(itemJsonPath);
        TextAsset quizJson = Resources.Load<TextAsset>(quizJsonPath);

        // Player = JsonUtility.FromJson<PlayerData>(playerJson.text);
        // Record = JsonUtility.FromJson<PlayerRecordData>(playerRecordJson.text);
        Buildings = JsonUtility.FromJson<BuildingDataList>(buildingJson.text);
        Departments = JsonUtility.FromJson<DepartmentDataList>(departmentJson.text);
        Lectures = JsonUtility.FromJson<LectureDataList>(lectureJson.text);
        Items = JsonUtility.FromJson<ItemDataList>(itemJson.text);
        Dialogue = JsonUtility.FromJson<DialogueDataList>(quizJson.text);
    }

    public static void SavePlayerData()
    {
        // string playerRecordJson = JsonUtility.ToJson(Record);

        Dictionary<string, string> data = new Dictionary<string, string>();

        data.Add("PlayerData", JsonUtility.ToJson(Player));
        data.Add("PlayerRecordData", JsonUtility.ToJson(Record));

        PlayfabMgr.Instance.SetUserData(data);
    }

    public static bool IsLastSemester()
    {
        int semester = Player.semester;

        if(semester == 8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}