using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _selectToggle, _recordToggle;
    [SerializeField] private GameObject _selectArea, _recordArea;
    [SerializeField] private GameObject _closeUi;

    [SerializeField] private Sprite _highlight;

    private Toggle _isSelect, _isRecord;
    private Color _defaultColor, _highlightColor;


    private void Awake()
    {
        _isSelect = _selectToggle.GetComponent<Toggle>();
        _isRecord = _recordToggle.GetComponent<Toggle>();

        _defaultColor = _selectToggle.GetComponent<Image>().color;
        _highlightColor = new Color(0.7f,0.7f,0.7f,1);

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

    public void CloseStudySelect()
    {
        _closeUi.SetActive(false);
    }
}
