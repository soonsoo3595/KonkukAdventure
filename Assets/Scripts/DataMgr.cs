using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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


public static class DataMgr
{
    // json 파일 경로
    private static string buildingJsonPath = "Assets/JSON/BuildingData.json";
    private static string departmentJsonPath = "Assets/JSON/DepartmentData.json";
    private static string lectureJsonPath = "Assets/JSON/LectureData.json";

    private static List<int> buildingRecord;
    private static List<LectureData> lectureRecord;

    public static BuildingDataList Buildings { get; private set; }
    public static DepartmentDataList Departments { get; private set; }
    public static LectureDataList Lectures { get; private set; }

    public static List<int> BuildingRecord = new List<int>();
    public static List<LectureData> LectureRecord = new List<LectureData>();

    public static void LoadData()
    {
        string buildingJson = File.ReadAllText(buildingJsonPath);
        string departmentJson = File.ReadAllText(departmentJsonPath);
        string lectureJson = File.ReadAllText(lectureJsonPath);


        Buildings = JsonUtility.FromJson<BuildingDataList>(buildingJson);
        Departments = JsonUtility.FromJson<DepartmentDataList>(departmentJson);
        Lectures = JsonUtility.FromJson<LectureDataList>(lectureJson);

    }
}