using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//이 스크립트 날려버리고 싶음
public class UIButtonManager : MonoBehaviour
{
    [Header("Top Toggle")]
    [SerializeField] private GameObject _selectToggle, _recordToggle;

    [Header("Area")]
    [SerializeField] private GameObject _selectArea, _recordArea;

    [Header("Sprite")]
    [SerializeField] private Sprite _highlight;

    private Toggle _isSelect, _isRecord;
    private Color _defaultColor, _highlightColor;


    private void Awake()
    {
        _isSelect = _selectToggle.GetComponent<Toggle>();
        _isRecord = _recordToggle.GetComponent<Toggle>();

        _defaultColor = _selectToggle.GetComponent<Image>().color;
        _highlightColor = new Color(0.7f, 0.7f, 0.7f, 1);

        _isSelect.isOn = true;
    }

    public void SelectButton()
    {
        _selectToggle.GetComponent<Image>().sprite = _highlight;
        _selectToggle.GetComponent<Image>().color = _highlightColor;

        _recordToggle.GetComponent<Image>().sprite = null;
        _recordToggle.GetComponent<Image>().color = _defaultColor;

        _selectArea.SetActive(true);
        _recordArea.SetActive(false);
    }

    public void RecordButton()
    {
        _selectToggle.GetComponent<Image>().sprite = null;
        _selectToggle.GetComponent<Image>().color = _defaultColor;

        _recordToggle.GetComponent<Image>().sprite = _highlight;
        _recordToggle.GetComponent<Image>().color = _highlightColor;

        _selectArea.SetActive(false);
        _recordArea.SetActive(true);
    }
}
