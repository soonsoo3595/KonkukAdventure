using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellMaker : MonoBehaviour
{
    //강의 리스트가 들어갈 단위
    [SerializeField] GameObject cell;
    //강의 리스트가 생성 될 위치
    [SerializeField] internal GameObject trans;
    //학과의 하위 강의들이 들어갈 배열
    [SerializeField] internal LectureDataSet[] study;

    //학과 아이디가 들어갈 리스트
    List<int> departmentID;
    //학과 이름들이 들어갈 리스트
    List<string> departmentNmae;

    // Start is called before the first frame update
    private void Awake()
    {
        //초기화
        departmentID = new List<int>();
        departmentNmae = new List<string>();
        //델리게이트 추가
        Portal.SetLectureData += MakeCell;
    }

    //셀 인스턴스와 동시에 텍스트 설정 메서드
    #region 셀 생성 및 텍스트 설정
    void MakeCell(List<DepartmentData> departDatas, List<LectureData> lectData)
    {
        //학과 데이터 세팅(학과 ID, 학과 이름 분리)
        SetData(departDatas);

        //학과 개수만큼 셀 인스턴스
        for (int i = 0; i < departDatas.Count; i++)
        {
            Instantiate(cell, trans.transform);
        }

        //인스턴스한 객체들 배열에 집어넣가
        study = GetComponentsInChildren<LectureDataSet>();

        //학과, 강의명 텍스로 붙이기
        for (int i = 0; i < study.Length; i++)
        {
            //학과 이름 텍스트로 붙이는 코드
            SetDepartText(i);

            //강의 이름 텍스트로 붙이는 코드
            study[i].SetLectureText(findLecture(departmentID[i], lectData));
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

    //학과명 세팅
    #region 학과명 세팅
    void SetDepartText(int num)
    {
        //셀 내부의 모든 텍스트 수집
        Text[] names = new Text[5];
        names = study[num].GetComponentsInChildren<Text>();
        //배열의 0번째를 제외한 나머지는 강의명 텍스트
        //따라서 학과명 세팅에서 건드려야 하는건 names[0]
        names[0].text = departmentNmae[num];
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
}
