using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

enum BuildNum
{
    #region 빌딩 번호
    b1 = 1, //행정관
    b2 = 2, //경영관
    b3 = 3, //상허연구관
    b4 = 4, //교육과학관
    b5 = 5, //예술문화관
    b6 = 6, //언어교육원
    b7 = 7, //박물관
    b8 = 8, //법학관
    b9 = 9, //상허기념도서관
    b10 = 10, //의생면과학연구관
    b11 = 11, //동물생명과학관
    b12 = 12, //입학정보관
    b13 = 13, //산학협동관
    b14 = 14, //수의학관
    b15 = 15, //새천년관
    b16 = 16, //건축관
    b17 = 17, //해봉부동산학관
    b18 = 18, //인문학관
    b19 = 19, //학생회관
    b20 = 20, //공학관
    b21 = 21, //신공학관
    b22 = 22, //과학관
    b23 = 23, //창의관
    b24 = 24, //온실
    b25 = 25, //경원당
    b26 = 26, //노천극장
    b27 = 27, //청심대
    b28 = 28, //KU스포츠광장
    b29 = 29, //일감호
    b30 = 30, //와우도
    b31 = 31 //홍예교
    #endregion 
}

public class Portal : MonoBehaviour
{
    public static Portal portal;

    #region 수강신청용 델리게이트 및 리스트
    //학과 데이터와 강의 데이터를 매개변수로 가지는 델리게이트 생성
    //해당 델리게이트는 수강신청 델리게이트
    public delegate void LectureChain(List<DepartmentData> departmentDatas, List<LectureData> lectureDatas);
    public static event LectureChain SetLectureData;

    //학과 데이터와 강의 데이터를 받을 리스트 선언
    List<DepartmentData> departmentDatas;
    List<LectureData> lectureDatas;
    #endregion

    #region 상점용 델리게이트 및 리스트
    //상점에 있는 아이템 리스트를 매개변수로 하는 델리게이트 선언
    public delegate void StoreChain( List<LectureItemData> LectureItemDatas, List<OtherItemData> OtherItemDatas);
    public static event StoreChain SetStoreData;

    //로드 할 때에 Json에 있는 정보가 들어갈곳
    List<LectureItemData> lectureItemDatas;
    List<OtherItemData> otherItemDatas;
    #endregion

    //포탈이 보여줄 빌딩의 번호 설정
    [SerializeField] BuildNum buildNum;
    internal int BuildNum { get { return (int)buildNum; } }

    // Start is called before the first frame update
    void Start()
    {
        portal = this;

        #region 데이터 get 코드
        //학과 데이터 Datamgr에서 가져오기
        departmentDatas = new List<DepartmentData>();
        departmentDatas = DataMgr.Departments.data;
        //강의 데이터 DataMgr에서 가져오기
        lectureDatas = new List<LectureData>();
        lectureDatas = DataMgr.Lectures.data;

        //아이템 데이터 DataMgr에서 가져오기
        lectureDatas = new List<LectureData>();
        lectureItemDatas = DataMgr.Items.data1;
        otherItemDatas = new List<OtherItemData>();
        otherItemDatas = DataMgr.Items.data2;
        #endregion

        //델리게이트 실행
        //만약 상점 이라면 상점 델리게이트 실행
        if (!((int)BuildNum).Equals(19))
        {
            SetLectureData(FindDepartment((int)buildNum), lectureDatas);
        }
        else SetStoreData(lectureItemDatas, otherItemDatas);
    }

    //캐릭터가 포탈 집입시에 발동
    #region 캐릭터 집입 이벤트
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if(other.CompareTag("Player"))
        {
            GameManager.instance.LectureUI.SetActive(true);
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
