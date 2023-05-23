using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#region 플레이어 데이터
[System.Serializable]
public class PlayerData
{
    public int userID;
    public int grade;
    public int semester;
    public int creditLimit;
    public int creditReserve;
    public int scoreReserve;
    public int KUPointReserve;
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

public static class DataMgr
{
    #region 수강 기록 코드...
    public static List<int> BuildingRecord = new List<int>();
    public static List<LectureData> LectureRecord = new List<LectureData>();
    #endregion

    // json 파일 경로
    #region Json 경로
    private static string playerJsonPath = "Assets/JSON/PlayerData.json";
    private static string buildingJsonPath = "Assets/JSON/BuildingData.json";
    private static string departmentJsonPath = "Assets/JSON/DepartmentData.json";
    private static string lectureJsonPath = "Assets/JSON/LectureData.json";
    private static string item1JsonPath = "Assets/JSON/ItemData.json";
    #endregion

    public static PlayerData player { get; set; }
    public static BuildingDataList Buildings { get; private set; }
    public static DepartmentDataList Departments { get; private set; }
    public static LectureDataList Lectures { get; private set; }
    public static ItemDataList Items { get; private set; }

    public static void LoadData()
    {
        string playerJson = File.ReadAllText(playerJsonPath);
        string buildingJson = File.ReadAllText(buildingJsonPath);
        string departmentJson = File.ReadAllText(departmentJsonPath);
        string lectureJson = File.ReadAllText(lectureJsonPath);
        string itemJson = File.ReadAllText(item1JsonPath);

        player = JsonUtility.FromJson<PlayerData>(playerJson);
        Buildings = JsonUtility.FromJson<BuildingDataList>(buildingJson);
        Departments = JsonUtility.FromJson<DepartmentDataList>(departmentJson);
        Lectures = JsonUtility.FromJson<LectureDataList>(lectureJson);
        Items = JsonUtility.FromJson<ItemDataList>(itemJson);
    }

    public static void SavePlayerData()
    {
        string playerJson = JsonUtility.ToJson(player);
        File.WriteAllText(playerJsonPath, playerJson);
    }
}