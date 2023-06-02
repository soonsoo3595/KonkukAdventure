using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#region 플레이어 데이터
[System.Serializable]
public class PlayerData
{
    public int userID;
    public string userName;
    public int grade;
    public int semester;
    public int creditLimit;
    public int creditReserve;
    public int scoreReserve;
    public int KUPointReserve;
    public bool isSemesterOver;
}

public class PlayerRecordData
{
    public int userID;
    public int totalCredit;
    public int totalKupoint;
    public int graduateCredit;
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

    // json 파일 경로
    #region Json 경로
    private static string playerJsonPath = "Assets/JSON/PlayerData.json";
    private static string playerRecordJsonPath = "Assets/JSON/PlayerRecordData.json";
    private static string buildingJsonPath = "Assets/JSON/BuildingData.json";
    private static string departmentJsonPath = "Assets/JSON/DepartmentData.json";
    private static string lectureJsonPath = "Assets/JSON/LectureData.json";
    private static string itemJsonPath = "Assets/JSON/ItemData.json";
    private static string quizJsonPath = "Assets/JSON/DialogueData.json";
    #endregion

    public static PlayerData player { get; set; }
    public static PlayerRecordData record { get; set; }
    public static BuildingDataList Buildings { get; private set; }
    public static DepartmentDataList Departments { get; private set; }
    public static LectureDataList Lectures { get; private set; }
    public static ItemDataList Items { get; private set; }
    public static DialogueDataList Dialogue { get; private set; }

    public static void LoadData()
    {
        string playerJson = File.ReadAllText(playerJsonPath);
        string playerRecordJson = File.ReadAllText(playerRecordJsonPath);
        string buildingJson = File.ReadAllText(buildingJsonPath);
        string departmentJson = File.ReadAllText(departmentJsonPath);
        string lectureJson = File.ReadAllText(lectureJsonPath);
        string itemJson = File.ReadAllText(itemJsonPath);
        string quizJson = File.ReadAllText(quizJsonPath);

        player = JsonUtility.FromJson<PlayerData>(playerJson);
        record = JsonUtility.FromJson<PlayerRecordData>(playerRecordJson);
        Buildings = JsonUtility.FromJson<BuildingDataList>(buildingJson);
        Departments = JsonUtility.FromJson<DepartmentDataList>(departmentJson);
        Lectures = JsonUtility.FromJson<LectureDataList>(lectureJson);
        Items = JsonUtility.FromJson<ItemDataList>(itemJson);
        Dialogue = JsonUtility.FromJson<DialogueDataList>(quizJson);
    }

    public static void SavePlayerData()
    {
        string playerJson = JsonUtility.ToJson(player);
        string playerRecordJson = JsonUtility.ToJson(record);
        File.WriteAllText(playerJsonPath, playerJson);
        File.WriteAllText(playerRecordJsonPath, playerRecordJson);
    }

    public static bool IsLastSemester()
    {
        int semester = player.semester;

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