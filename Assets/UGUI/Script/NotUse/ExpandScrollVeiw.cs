using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandScrollVeiw : MonoBehaviour
{
    public static ExpandScrollVeiw instance;

    [SerializeField] internal GameObject trans;
    [SerializeField] internal ExpandArea[] study;
    [SerializeField] internal float area, time;
    private bool[] _isExpand;
    private bool _isStudy1Expand, _isStudy2Expand, _isStudy3Expand, _isStudy4Expand;

    private void Start()
    {
        instance = this;
        study = trans.GetComponentsInChildren<ExpandArea>();
        SetText(1);

        _isExpand = new bool[study.Length];

        _isStudy1Expand = false;
        _isStudy2Expand = false;
        _isStudy3Expand = false;
        _isStudy4Expand = false;
    }

    void SetText(int num)
    {
        Text[] names = new Text[5];

        names = study[num].GetComponentsInChildren<Text>();
        names[1].text = "texssksksksksk";
        Debug.Log(names);
        Debug.Log("fsdkjghdkfg");
    }

    public void ExpandStudy1()
    {
        if (!_isStudy1Expand)
        {

            for (int i = 1; i < study.Length; i++)
            {
                StartCoroutine(SmoothResizeDown(study[i], area, time)) ;
            }

            _isStudy1Expand = true;
        }
        else
        {
            for (int i = 1; i < study.Length; i++)
            {
                StartCoroutine(SmoothResizeUp(study[i], area, time)) ;
            }

            _isStudy1Expand = false;
        }
    }
    public void ExpandStudy2()
    {
        if (!_isStudy2Expand)
        {
            for (int i = 2; i < study.Length; i++)
            {
                StartCoroutine(SmoothResizeDown(study[i],area,time));
            }

            _isStudy2Expand = true;
        }
        else
        {
            for (int i = 2; i < study.Length; i++)
            {
                StartCoroutine(SmoothResizeUp(study[i], area, time));
            }

            _isStudy2Expand = false;
        }
    }
    public void ExpandStudy3()
    {
        if (!_isStudy3Expand)
        {
            for (int i = 3; i < study.Length; i++)
            {
                StartCoroutine(SmoothResizeDown(study[i], area, time));
            }

            _isStudy3Expand = true;
        }
        else
        {
            for (int i = 3; i < study.Length; i++)
            {
                StartCoroutine(SmoothResizeUp(study[i], area, time));
            }

            _isStudy3Expand = false;
        }
    }
    public void ExpandStudy4()
    {
        if (!_isStudy4Expand)
        {
            for (int i = 4; i < study.Length; i++)
            {
                StartCoroutine(SmoothResizeDown(study[i], area, time));
            }

            _isStudy4Expand = true;
        }
        else
        {
            for (int i = 4; i < study.Length; i++)
            {
                StartCoroutine(SmoothResizeUp(study[i], area, time));
            }

            _isStudy4Expand = false;
        }
    }

    #region 스크롤 확장/감소
    IEnumerator SmoothResizeUp(ExpandArea rt, float area , float time)
    {
        float t = 0f;
        float temp = rt.transform.position.y;

        while (t < 1f)
        {
            t += Time.deltaTime / time;
            if (t > 1) t = 1;
            float growSize = area * t;
            rt.transform.position = new Vector3(rt.transform.position.x, temp + growSize, rt.transform.position.z);
            yield return null;
        }
    }
    IEnumerator SmoothResizeDown(ExpandArea rt, float area, float time)
    {
        float t = 0f;
        float temp = rt.transform.position.y;

        while (t < 1f)
        {
            t += Time.deltaTime / time;
            if (t > 1) t = 1;
            float growSize = area * t;
            rt.transform.position = new Vector3(rt.transform.position.x, temp - growSize, rt.transform.position.z);
            yield return null;
        }
    }
    #endregion
}
