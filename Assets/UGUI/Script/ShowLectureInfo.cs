using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLectureInfo : MonoBehaviour
{
    [SerializeField] private GameObject _lectureInfo;

    private void Awake()
    {
        _lectureInfo.SetActive(false);
    }

    public void ShowInfo()
    {
        _lectureInfo.SetActive(true);
    }
}
