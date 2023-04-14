using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

enum BuildNum
{
    #region ���� ��ȣ
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

    //�а� �����Ϳ� ���� �����͸� �Ű������� ������ ��������Ʈ ����
    public delegate void SetDataChain(List<DepartmentData> departmentDatas, List<LectureData> lectureDatas);
    public static event SetDataChain SetData;

    //�а� �����Ϳ� ���� �����͸� ���� ����Ʈ ����
    List<DepartmentData> departmentDatas;
    List<LectureData> lectureDatas;

    //��Ż�� ������ ������ ��ȣ ����
    [SerializeField] BuildNum buildNum;
    internal int BuildNum { get { return (int)buildNum; } }

    // Start is called before the first frame update
    void Start()
    {
        portal = this;

        //�а� ������ Datamgr���� ��������
        departmentDatas = new List<DepartmentData>();
        departmentDatas = DataMgr.Departments.data;
        //���� ������ DataMgr���� ��������
        lectureDatas = new List<LectureData>();
        lectureDatas = DataMgr.Lectures.data;

        //��������Ʈ ����
        SetData(FindDepartment((int)buildNum), lectureDatas);  
    }

    //ĳ���Ͱ� ��Ż ���Խÿ� �ߵ�
    #region ĳ���� ���� �̺�Ʈ
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if(other.CompareTag("Player"))
        {
            GameManager.instance.selectUi.SetActive(true);
        }
    }
    #endregion

    //���� ��ȣ�� ���� �а��� �˻�
    #region ������ �ִ� �а��� �˻�
    private List<DepartmentData> FindDepartment(int num)
    {
        List<DepartmentData> find = departmentDatas.FindAll(element => element.buildingID == num);
        return find;
    }
    #endregion
}
