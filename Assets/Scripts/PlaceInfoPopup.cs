using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaceInfoPopup : MonoBehaviour
{
    public PlaceInfo[] places;

    public TextMeshProUGUI placeName, description;
    public Image placeImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetPopup(int placeNum)
    {
        placeName.text = $"이곳은 {places[placeNum].placeName} 입니다";
        description.text = places[placeNum].placeDescription;
        placeImage.sprite = places[placeNum].placeImage;
    }    
}
