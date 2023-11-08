using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlaceInfo", menuName = "ScriptableObjects/PlaceInfo", order = 1)]
public class PlaceInfo : ScriptableObject
{
    
    public Sprite placeImage;
    public string placeName;
    [TextArea(1,10)]
    public string placeDescription;
}
