using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CellMaker : MonoBehaviour
{
    //강의 리스트가 들어갈 단위
    [SerializeField] private GameObject cell;
    //강의 리스트가 생성 될 위치
    [SerializeField] internal GameObject trans;
    //학과의 하위 강의들이 들어갈 배열
    [SerializeField] internal List<GameObject> study;

    //학과 아이디가 들어갈 리스트
    List<int> departmentID;
    //학과 이름들이 들어갈 리스트
    [SerializeField] List<string> departmentNmae;

    // Start is called before the first frame update
    private void Awake()
    {
        //초기화
        departmentID = new List<int>();
        departmentNmae = new List<string>();
        study = new List<GameObject>();
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
    void MakeCell(List<DepartmentData> departDatas, List<LectureData> lectData)
    {
        SetData(departDatas);

        //학과, 강의명 텍스로 붙이기
        for (int i = 0; i < departDatas.Count; i++)
        {
            study[i].SetActive(true);
            //학과 이름 텍스트로 붙이는 코드
            study[i].GetComponentInChildren<TMP_Text>().text = departmentNmae[i];
            study[i].GetComponent<LectureDataSet>().lectureData = findLecture(departmentID[i], lectData);
        }
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

    // 학과 ID에 따른 강의들 검색
    #region 학과ID를 통해 강의 검색
    List<LectureData> findLecture(int departmentID, List<LectureData> data)
    {
        List<LectureData> find = data.FindAll(element => element.departmentID == departmentID);

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
