using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // �ǹ� ��ȣ �ν����� â���� �Է¹ް� Ʈ���� �߻� �� �������� ��ȣ�� �̿��ؼ� ������ �޾ƿ��� UI ����
    public int buildingNum;
    public TextAsset jsonFile;

    [System.Serializable]
    public class BuildingData
    {
        public int buildingID;
        public string name;
        public string subType;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            BuildingData data = JsonUtility.FromJson<BuildingData>(jsonFile.text);
            Debug.Log(data);
        }
    }
}
