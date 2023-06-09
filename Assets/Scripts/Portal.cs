using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

enum BuildNum
{
    #region 빌딩 번호
    행정관 = 1,
    경영관 = 2,//경영대
    상허연구관 = 3,//사회과대학
    교육과학관 = 4,//사범대
    예술문화관 = 5,//예술디자인대학
    언어교육원 = 6,
    박물관 = 7,
    법학관 = 8,
    상허기념도서관 = 9,
    의생면과학연구관 = 10,
    동물생명과학관 = 11,//상허생명과학대학
    입학정보관 = 12,
    산학협동관 = 13,
    수의학관 = 14,//수의과대학
    새천년관 = 15,
    건축관 = 16,//건축대학
    해봉부동산학관 = 17,//부동산과학원
    인문학관 = 18,//문과대학
    학생회관 = 19,//상점
    공학관 = 20,//공과대학
    신공학관 = 21,//KU융합과학기술원
    과학관 = 22,//이과대학
    창의관 = 23,
    온실 = 24,
    경원당 = 25,
    노천극장 = 26,
    청심대 = 27,
    KU스포츠광장 = 28,
    일감호 = 29,
    와우도 = 30,
    홍예교 = 31,
    퀴즈이벤트1 = 32,
    퀴즈이벤트2 = 33,
    퀴즈이벤트3 = 34
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
    public delegate void StoreChain(ItemDataList itemDataList);
    public static event StoreChain SetStoreData;
    //로드 할 때에 Json에 있는 정보가 들어갈곳
    ItemDataList itemDataList;
    #endregion

    #region 퀴즈 번호 체크
    public delegate void SetDialogueChain(int num);
    public static event SetDialogueChain SetDialogue;
    #endregion

    //포탈이 보여줄 빌딩의 번호 설정
    [SerializeField] BuildNum buildNum;
    internal int BuildNum { get { return (int)buildNum; } }

    private void Start()
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
        itemDataList = DataMgr.Items;
        #endregion
    }

    //캐릭터가 포탈 집입시에 발동
    #region 캐릭터 집입 이벤트
    private void OnTriggerEnter(Collider other)
    {
        Popup popup;

        if(other.CompareTag("Player"))
        {
            //델리게이트 실행
            //만약 상점 이라면 상점 델리게이트 실행
            switch (BuildNum)
            {
                //강의 건물 진입
                case 2:
                case 3:
                case 4:
                case 5:
                case 11:
                case 14:
                case 16:
                case 17:
                case 18:
                case 20:
                case 21:
                case 22:
                    popup = PopupMgr.instance.selectStudyPopup;
                    PopupMgr.instance.OpenPopup(popup);
                    SetLectureData(FindDepartment((int)buildNum), lectureDatas);
                    break;
               //상점 진입
                case 19:
                    popup = PopupMgr.instance.storePopup;
                    PopupMgr.instance.OpenPopup(popup);
                    SetStoreData(itemDataList);
                    break;
                //퀴즈 이벤트 진입
                case 32:
                case 33:
                case 34:
                    popup = PopupMgr.instance.dialoguePopup;
                    PopupMgr.instance.OpenPopup(popup);
                    SetDialogue(BuildNum);
                    break;
            }
        }
    }
    #endregion

    private void OnTriggerExit(Collider other)
    {
        Popup popup;

        if (other.CompareTag("Player"))
        {
            switch ((int)buildNum)
            {
                //강의 건물 진입
                case 2:
                case 3:
                case 4:
                case 5:
                case 11:
                case 14:
                case 16:
                case 17:
                case 18:
                case 20:
                case 21:
                case 22:
                    popup = PopupMgr.instance.selectStudyPopup;
                    PopupMgr.instance.ClosePopup(popup);
                    break;
                //상점 진입
                case 19:
                    popup = PopupMgr.instance.storePopup;
                    PopupMgr.instance.ClosePopup(popup);
                    break;
                //퀴즈 이벤트 진입
                case 32:
                case 33:
                case 34:
                    popup = PopupMgr.instance.dialoguePopup;
                    PopupMgr.instance.ClosePopup(popup);
                    break;
            }
        }
    }
    //빌딩 번호에 따른 학과들 검색
    #region 빌딩에 있는 학과들 검색
    private List<DepartmentData> FindDepartment(int num)
    {
        List<DepartmentData> find = departmentDatas.FindAll(element => element.buildingID == num);
        return find;
    }
    #endregion
}
