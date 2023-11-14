using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Ricimi;

public enum BuildNum
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
    의생명과학연구관 = 10,
    생명과학관 = 11, 
    동물생명과학관 = 12, //상허생명과학대학
    입학정보관 = 13,
    산학협동관 = 14,
    수의학관 = 15,//수의과대학
    새천년관 = 16,
    건축관 = 17,//건축대학
    해봉부동산학관 = 18,//부동산과학원
    인문학관 = 19,//문과대학
    학생회관 = 20,//상점
    공학관 = 21,//공과대학
    신공학관 = 22,//KU융합과학기술원
    과학관 = 23,//이과대학
    창의관 = 24,
    경원당 = 25,
    쿨하우스 = 26,
    노천극장 = 27,
    청심대 = 28,
    KU스포츠광장 = 29,
    건국대학교병원 = 30,
    일감호 = 31,
    와우도 = 32,
    홍예교 = 33,
    설립자묘소 = 34,
    //퀴즈
    퀴즈이벤트1 = 35,
    퀴즈이벤트2 = 36,
    퀴즈이벤트3 = 37,
    //Npc
    가이드 = 100,
    학생1 = 101
    #endregion 
}

public class Portal : MonoBehaviour
{
    public PlaceInfoPopup placeInfoPopup;

    public static Portal portal;

    public GameObject infoIcon;

    #region 수강신청용 델리게이트 및 리스트
    //학과 데이터와 강의 데이터를 매개변수로 가지는 델리게이트 생성
    //해당 델리게이트는 수강신청 델리게이트
    public delegate void LectureChain(int buildNum);
    public static event LectureChain SetLectureData;
    #endregion

    #region 상점용 델리게이트 및 리스트
    //상점에 있는 아이템 리스트를 매개변수로 하는 델리게이트 선언
    public delegate void StoreChain(ItemDataList itemDataList);
    public static event StoreChain SetStoreData;
    //로드 할 때에 Json에 있는 정보가 들어갈곳
    ItemDataList itemDataList;
    #endregion

    #region NPC 델리게이트
    public delegate void NpcChain(String NpcName);
    public static event NpcChain NpcIn;
    public static event NpcChain NpcOut;
    #endregion

    #region 퀴즈 번호 체크
    public delegate void SetDialogueChain(int num);
    public static event SetDialogueChain SetDialogue;
    #endregion

    //포탈이 보여줄 빌딩의 번호 설정
    [SerializeField] BuildNum buildNum;

    private QuestManager _questManager;
    internal int BuildNum { get { return (int)buildNum; } }

    private void Start()
    {
        portal = this;
        _questManager = QuestManager.questManager;

        #region 데이터 get 코드
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
            QuestManager.questManager.CheckQuest(BuildNum);

            ///포탈의 콜라이더가 트리거 되었을 때
            ///퀘스트 체크를 최초에 실행한다.
            ///QuestManager에서 다이얼로그 팝업과 보상 지급 진행
            // if (_questManager.CheckQuest((BuildNum))) return;

            //델리게이트 실행
            //만약 상점 이라면 상점 델리게이트 실행

            if (placeInfoPopup != null)
            {
                placeInfoPopup.SetPopup(BuildNum);
                popup = PopupMgr.instance.placeInfoPopup;
                PopupMgr.instance.OpenPopup(popup);
            }
            else
            {
                ActivatePopup(BuildNum);
            }
        }
    }
    #endregion

    //캐릭터 진입 해제시 발동
    #region 캐릭터 진입 해제 이벤트
    public void OnTriggerExit(Collider other)
    {
        if(placeInfoPopup != null) PopupMgr.instance.ClosePopup(PopupMgr.instance.placeInfoPopup);
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
                case 12:
                case 15:
                case 17:
                case 18:
                case 19:
                case 21:
                case 22:
                case 23:
                    popup = PopupMgr.instance.selectStudyPopup;
                    PopupMgr.instance.ClosePopup(popup);
                    break;
                //상점 진입
                case 20:
                    popup = PopupMgr.instance.storePopup;
                    PopupMgr.instance.ClosePopup(popup);
                    break;
                //퀴즈 이벤트 진입
                case 32:
                case 33:
                case 34:
                case 100:
                    popup = PopupMgr.instance.dialoguePopup;
                    PopupMgr.instance.ClosePopup(popup);
                    NpcOut("");
                    break;
                case 101:
                    popup = PopupMgr.instance.dialoguePopup;
                    PopupMgr.instance.ClosePopup(popup);
                    NpcOut("");
                    break;
            }
        }
    }
    #endregion

    public void ActivatePopup(int placeNum)
    {
        Popup popup;

        switch (placeNum)
        {
            //강의 건물 진입
            case 2:
            case 3:
            case 4:
            case 5:
            case 12:
            case 15:
            case 17:
            case 18:
            case 19:
            case 21:
            case 22:
            case 23:
                popup = PopupMgr.instance.selectStudyPopup;
                PopupMgr.instance.OpenPopup(popup);
                SetLectureData(placeNum);
                break;
            //상점 해제
            case 20:
                popup = PopupMgr.instance.storePopup;
                PopupMgr.instance.OpenPopup(popup);
                SetStoreData(itemDataList);
                break;
            //퀴즈 이벤트 해제
            case 32:
            case 33:
            case 34:
                popup = PopupMgr.instance.dialoguePopup;
                PopupMgr.instance.OpenPopup(popup);
                SetDialogue(placeNum);
                break;
            case 100:
                popup = PopupMgr.instance.dialoguePopup;
                PopupMgr.instance.OpenPopup(popup);
                NpcIn("Guide");
                break;
            case 101:
                popup = PopupMgr.instance.dialoguePopup;
                PopupMgr.instance.OpenPopup(popup);
                NpcIn("Student1");
                break;
        }
    }
}
