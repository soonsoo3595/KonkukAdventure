using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandScrollVeiw : MonoBehaviour
{
    public static ExpandScrollVeiw instance;

    [SerializeField] RectTransform view;
    [SerializeField] internal GameObject[] study = new GameObject[4];
    [SerializeField] internal float area, time;
    bool isStudy1Expand, isStudy2Expand, isStudy3Expand;

    private void Awake()
    {
        instance = this;

        isStudy1Expand = false;
        isStudy2Expand = false;
        isStudy3Expand = false;
    }
    public void ExpandStudy1()
    {
        if (!isStudy1Expand)
        {

            for (int i = 1; i < 4; i++)
            {
                StartCoroutine(SmoothResizeDown(study[i], area, time)) ;
            }

            isStudy1Expand = true;
        }
        else
        {
            for (int i = 1; i < 4; i++)
            {
                StartCoroutine(SmoothResizeUp(study[i], area, time)) ;
            }


            isStudy1Expand = false;
        }
    }
    public void ExpandStudy2()
    {
        if (!isStudy2Expand)
        {
            for (int i = 2; i < 4; i++)
            {
                StartCoroutine(SmoothResizeDown(study[i],area,time));
            }

            isStudy2Expand = true;
        }
        else
        {
            for (int i = 2; i < 4; i++)
            {
                StartCoroutine(SmoothResizeUp(study[i], area, time));
            }

            isStudy2Expand = false;
        }
    }
    public void ExpandStudy3()
    {
        if (!isStudy3Expand)
        {
            StartCoroutine(SmoothResizeDown(study[3], area, time));

            isStudy3Expand = true;
        }
        else
        {
            StartCoroutine(SmoothResizeUp(study[3], area, time)) ;

            isStudy3Expand = false;
        }
    }

    IEnumerator SmoothResizeUp(GameObject rt, float area , float time)
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
    IEnumerator SmoothResizeDown(GameObject rt, float area, float time)
    {
        float t = 0f, a = 0;
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

    void WaitTime()
    {

    }
}
