using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellMaker : MonoBehaviour
{
    //생성 할 셀
    [SerializeField] GameObject cell;
    //셀들이 생성 될 위치
    [SerializeField] internal GameObject trans;
    //셀들이 들어갈 배열
    [SerializeField] internal ExpandArea[] study;

    //들어간 건물의 학과 정보를 받을 배열들
    List<DepartmentData> datas;
    List<int> departmentID;
    List<string> departmentNmae;

    // Start is called before the first frame update
    private void Awake()
    {
        datas = new List<DepartmentData>();
        departmentID = new List<int>();
        departmentNmae = new List<string>();
    }

    // Start is called before the first frame update
    void Start()
    {
        study = trans.GetComponentsInChildren<ExpandArea>();

        //셀 생성
        //포탈이 활성화 된 타이밍에 실행
    }

    private void OnEnable()
    {
        MakeCell();
    }

    void MakeCell()
    {
        datas = GameManager.instacne.portal.findData;
        Debug.Log(datas.Count);
        SetData();

        //셀 생성
        for (int i = 0; i < datas.Count; i++)
        {
            Instantiate(cell, trans.transform);
        }

        //생성한 셀의 학과 이름 설정
        for(int i = 0; i < study.Length; i++)
        {
            SetText(i);
        }
    }

    void SetData()
    {
        for(int i = 0; i < datas.Count; i++)
        {
            departmentID.Add(datas[i].departmentID);
            departmentNmae.Add(datas[i].name);
        }
    }

    void SetText(int num)
    {
        Text[] names = new Text[5];

        names = study[num].GetComponentsInChildren<Text>();
        names[0].text = departmentNmae[num];
    }           
}
