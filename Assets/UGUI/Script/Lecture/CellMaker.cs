using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CellMaker : MonoBehaviour
{

    //학과 데이터를 받을 리스트 선언
    List<DepartmentData> departmentDatas;
    //강의 데이터를 받을 리스트 선언
    List<LectureData> lectureDatas;

    //강의 리스트가 들어갈 단위
    [SerializeField] private GameObject cell;
    //강의 리스트가 생성 될 위치
    [SerializeField] internal GameObject trans;
    [SerializeField] private TMP_Text buildName;
    //학과의 하위 강의들이 들어갈 배열
    [SerializeField] internal List<GameObject> study;

    //학과 아이디가 들어갈 리스트
    List<int> departmentID;
    //학과 이름들이 들어갈 리스트
    [SerializeField] List<string> departmentNmae;

    private Scrollbar scrollbar;

    // Start is called before the first frame update
    private void Awake()
    {
        #region 초기화
        //학과 데이터 Datamgr에서 가져오기
        departmentDatas = new List<DepartmentData>();
        departmentDatas = DataMgr.Departments.data;
        //강의 데이터 DataMgr에서 가져오기
        lectureDatas = new List<LectureData>();
        lectureDatas = DataMgr.Lectures.data;

        //초기화
        departmentID = new List<int>();
        departmentNmae = new List<string>();
        study = new List<GameObject>();
        scrollbar = this.GetComponentInChildren<Scrollbar>();
        #endregion

        //델리게이트 추가
        Portal.SetLectureData += MakeCell;

        //10개정도 인스턴스 한 셀을 활성화 하면서
        //셀을 보여줄거임
        for (int i = 0; i < 10; i++)
        {
            study.Add(Instantiate(cell, trans.transform));
            study[i].SetActive(false);
        }
    }

    //셀 인스턴스와 동시에 텍스트 설정 메서드
    #region 셀 생성 및 텍스트 설정
    void MakeCell(int buildNum)
    {
        List<DepartmentData> departDatas = FindDepartment(buildNum);
        SetData(departDatas);

        //빌딩 이름 - 단과대 이름 텍스트 붙이기
        buildName.text = $"{DataMgr.Buildings.data[buildNum - 1].name}: {DataMgr.Buildings.data[buildNum - 1].subType}";

        //학과, 강의명 텍스로 붙이기
        for (int i = 0; i < departDatas.Count; i++)
        {
            study[i].SetActive(true);
            //학과 이름 텍스트로 붙이는 코드
            study[i].GetComponentInChildren<TMP_Text>().text = departmentNmae[i];
            study[i].GetComponent<LectureDataSet>().lectureData = FindLecture(departmentID[i]);
        }
        scrollbar.value = 1;
    }
    #endregion

    //학과 데이터 학과ID, 학과 이름 두개로 분리
    #region 학과 데이터 ID와 이름으로 분리
    void SetData(List<DepartmentData> departDatas)
    {
        for(int i = 0; i < departDatas.Count; i++)
        {
            departmentID.Add(departDatas[i].departmentID);
            departmentNmae.Add(departDatas[i].name);
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

    // 학과 ID에 따른 강의들 검색
    #region 학과ID를 통해 강의 검색
    List<LectureData> FindLecture(int departmentID)
    {
        List<LectureData> find = lectureDatas.FindAll(element => element.departmentID == departmentID);

        return find;
    }
    #endregion

    //닫으면 초기화
    private void OnDisable()
    {
        for(int i = 0; i < study.Count; i++)
        {
            study[i].gameObject.SetActive(false);
            departmentID.Clear();
            departmentNmae.Clear();
        }
    }
}
