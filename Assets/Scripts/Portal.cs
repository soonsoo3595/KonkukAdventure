using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

enum BuildNum
{
    #region 빌딩 번호
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
    #endregion 
}

public class Portal : MonoBehaviour
{
    public static Portal portal;

    //학과 데이터와 강의 데이터를 매개변수로 가지는 델리게이트 생성
    public delegate void SetDataChain(List<DepartmentData> departmentDatas, List<LectureData> lectureDatas);
    public static event SetDataChain SetData;

    //학과 데이터와 강의 데이터를 받을 리스트 선언
    List<DepartmentData> departmentDatas;
    List<LectureData> lectureDatas;

    //포탈이 보여줄 빌딩의 번호 설정
    [SerializeField] BuildNum buildNum;
    internal int BuildNum { get { return (int)buildNum; } }

    // Start is called before the first frame update
    void Start()
    {
        portal = this;

        //학과 데이터 Datamgr에서 가져오기
        departmentDatas = new List<DepartmentData>();
        departmentDatas = DataMgr.Departments.data;
        //강의 데이터 DataMgr에서 가져오기
        lectureDatas = new List<LectureData>();
        lectureDatas = DataMgr.Lectures.data;

        //델리게이트 실행
        SetData(FindDepartment((int)buildNum), lectureDatas);  
    }

    //캐릭터가 포탈 집입시에 발동
    #region 캐릭터 집입 이벤트
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if(other.CompareTag("Player"))
        {
            GameManager.instance.selectUi.SetActive(true);
        }
    }
    #endregion

    //빌딩 번호에 따른 학과들 검색
    #region 빌딩에 있는 학과들 검색
    private List<DepartmentData> FindDepartment(int num)
    {
        List<DepartmentData> find = departmentDatas.FindAll(element => element.buildingID == num);
        return find;
    }
    #endregion
}
