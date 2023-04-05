using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

enum BuildNum
{
    b1 = 1,
    b2 = 2,
    b3 = 3,
    b4 = 4,
    b5 = 5,
    b6 = 6,
    b7 = 7,
    b8 = 8,
    b9 = 9,
    b10 = 10,
    b11 = 11,
    b12 = 12,
    b13 = 13,
    b14 = 14,
    b15 = 15,
    b16 = 16,
    b17 = 17,
    b18 = 18,
    b19 = 19,
    b20 = 20,
    b21 = 21,
    b22 = 22,
    b23 = 23,
    b24 = 24,
    b25 = 25,
    b26 = 26,
    b27 = 27,
    b28 = 28,
    b29 = 29,
    b30 = 30,
    b31 = 31
}

public class Portal : MonoBehaviour
{

    public List<DepartmentData> findData;
    List<DepartmentData> data;

    [SerializeField] BuildNum buildNum;

    // 건물 번호 인스펙터 창에서 입력받고 트리거 발생 시 서버에서 번호를 이용해서 데이터 받아오고 UI 띄우기

    // Start is called before the first frame update
    void Start()
    {
        findData = new List<DepartmentData>();
        data = new List<DepartmentData>();
        data = DataMgr.Departments.data;

        findData = FindDepartment(5);

        //for(int i = 0;i<57;i++)
        //{
        //    departmentID[i] = data[i].departmentID;
        //    buildingID[i] = data[i].buildingID;
        //    departmentName[i] = data[i].name;
        //}
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if(other.CompareTag("Player"))
        {

            GameManager.instacne.selectUi.SetActive(true);
        }
    }

    public List<DepartmentData> FindDepartment(int num)
    {
        List<DepartmentData> findID = data.FindAll(element => element.buildingID == num);

        return findID;
    }

}
