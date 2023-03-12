using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Object/Building Data")]
public class BuildingData : ScriptableObject
{
    public int buildingNum; // 건물 번호
    public string buildingName; // 건물 이름
    public BuildingType buildingType; // 건물 타입


    [TextArea] public string buildingDescription;  // 건물 설명

}
