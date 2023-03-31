using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // 건물 번호 인스펙터 창에서 입력받고 트리거 발생 시 서버에서 번호를 이용해서 데이터 받아오고 UI 띄우기
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
