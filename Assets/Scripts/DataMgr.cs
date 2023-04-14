using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#region �ǹ� ������
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
    // �� List<BuildingData>�� �������� json���Ͽ� ���� ó���� �ִ� �̸��� ���ƾ� ��!!
    public List<BuildingData> data;
}
#endregion

#region �а� ������
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

#region ���� ������
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
    // json ���� ���
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