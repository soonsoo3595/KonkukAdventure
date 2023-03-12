using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] BuildingData buildingData;


    [Header("Popup")]
    public GameObject popup;
    public Text popup_name;
    public Text popup_num;
    public Text popup_desc;


    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            popup_name.text = buildingData.buildingName;
            popup_num.text = buildingData.buildingNum.ToString();
            popup_desc.text = buildingData.buildingDescription;

            popup.SetActive(true);

            Debug.Log("건물에 들어왔습니다");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            popup.SetActive(false);

            Debug.Log("건물에서 나갑니다");
        }
    }
}
