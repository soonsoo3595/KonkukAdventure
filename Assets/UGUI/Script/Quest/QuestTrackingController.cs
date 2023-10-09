using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTrackingController : MonoBehaviour
{
    public static QuestTrackingController questTracking;

    [SerializeField] GameObject portalPool;
    [SerializeField] public Image navigator;

    public bool isTrackingFlag;

    private Portal[] _portals;
    private void Awake()
    {
        questTracking = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        navigator.gameObject.SetActive(false);
        _portals = portalPool.GetComponentsInChildren<Portal>();
        QuestObjectController.Tracking += NavigatePortal;
    }

    bool NavigatePortal(int buildingNum)
    {
        if (SearchPortal(buildingNum).Equals(null)) return true;

        if (isTrackingFlag) Debug.Log("새로운 퀘스트를 추적합니다!");

        navigator.gameObject.SetActive(true);
        isTrackingFlag = true;

        Vector3 trackingPosition = SearchPortal(buildingNum).position;
        StartCoroutine(Tracking_Update(trackingPosition));

        return false;
    }

    Transform SearchPortal(int buildingNum)
    {
        foreach(Portal portal in _portals)
        {
            if (portal.BuildNum.Equals(buildingNum))
            {
                return portal.transform;
            }
        }
        return null;
    }

    IEnumerator Tracking_Update(Vector3 target)
    {
        while (isTrackingFlag)
        {
            float angleRad = Mathf.Atan2(target.z, target.x);
            float angleDeg = (180 / Mathf.PI) * angleRad;
            navigator.transform.rotation = Quaternion.Euler(-90, 0, angleDeg);

            yield return null;
        }
    }
}
