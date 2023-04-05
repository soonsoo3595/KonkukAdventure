using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellMaker : MonoBehaviour
{
    //���� �� ��
    [SerializeField] GameObject cell;
    //������ ���� �� ��ġ
    [SerializeField] internal GameObject trans;
    //������ �� �迭
    [SerializeField] internal ExpandArea[] study;

    //�� �ǹ��� �а� ������ ���� �迭��
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

        //�� ����
        //��Ż�� Ȱ��ȭ �� Ÿ�ֿ̹� ����
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

        //�� ����
        for (int i = 0; i < datas.Count; i++)
        {
            Instantiate(cell, trans.transform);
        }

        //������ ���� �а� �̸� ����
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
