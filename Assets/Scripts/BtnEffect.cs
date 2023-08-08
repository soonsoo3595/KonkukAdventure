using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BtnEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI startText;
    public Color color;

    Button btn;

    void Awake()
    {
        btn = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        startText.color = color;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        startText.color = Color.white;
    }

}
