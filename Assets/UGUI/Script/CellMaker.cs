using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellMaker : MonoBehaviour
{
    //���� ����Ʈ�� �� ����
    [SerializeField] GameObject cell;
    //���� ����Ʈ�� ���� �� ��ġ
    [SerializeField] internal GameObject trans;
    //�а��� ���� ���ǵ��� �� �迭
    [SerializeField] internal LectureDataSet[] study;

    //�а� ���̵� �� ����Ʈ
    List<int> departmentID;
    //�а� �̸����� �� ����Ʈ
    List<string> departmentNmae;

    // Start is called before the first frame update
    private void Awake()
    {
        //�ʱ�ȭ
        departmentID = new List<int>();
        departmentNmae = new List<string>();
        //��������Ʈ �߰�
        Portal.SetData += MakeCell;
    }

    //�� �ν��Ͻ��� ���ÿ� �ؽ�Ʈ ���� �޼���
    #region �� ���� �� �ؽ�Ʈ ����
    void MakeCell(List<DepartmentData> departDatas, List<LectureData> lectData)
    {
        //�а� ������ ����(�а� ID, �а� �̸� �и�)
        SetData(departDatas);

        //�а� ������ŭ �� �ν��Ͻ�
        for (int i = 0; i < departDatas.Count; i++)
        {
            Instantiate(cell, trans.transform);
        }

        //�ν��Ͻ��� ��ü�� �迭�� ����ְ�
        study = GetComponentsInChildren<LectureDataSet>();

        //�а�, ���Ǹ� �ؽ��� ���̱�
        for (int i = 0; i < study.Length; i++)
        {
            //�а� �̸� �ؽ�Ʈ�� ���̴� �ڵ�
            SetDepartText(i);

            //���� �̸� �ؽ�Ʈ�� ���̴� �ڵ�
            study[i].SetLectureText(findLecture(departmentID[i], lectData));
        }
    }
    #endregion

    //�а� ������ �а�ID, �а� �̸� �ΰ��� �и�
    #region �а� ������ ID�� �̸����� �и�
    void SetData(List<DepartmentData> departDatas)
    {
        for(int i = 0; i < departDatas.Count; i++)
        {
            departmentID.Add(departDatas[i].departmentID);
            departmentNmae.Add(departDatas[i].name);
        }
    }
    #endregion

    //�а��� ����
    #region �а��� ����
    void SetDepartText(int num)
    {
        //�� ������ ��� �ؽ�Ʈ ����
        Text[] names = new Text[5];
        names = study[num].GetComponentsInChildren<Text>();
        //�迭�� 0��°�� ������ �������� ���Ǹ� �ؽ�Ʈ
        //���� �а��� ���ÿ��� �ǵ���� �ϴ°� names[0]
        names[0].text = departmentNmae[num];
    }
    #endregion

    // �а� ID�� ���� ���ǵ� �˻�
    #region �а�ID�� ���� ���� �˻�
    List<LectureData> findLecture(int departmentID, List<LectureData> data)
    {
        List<LectureData> find = data.FindAll(element => element.departmentID == departmentID);

        return find;
    }
    #endregion
}
