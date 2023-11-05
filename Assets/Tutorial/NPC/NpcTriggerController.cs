using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NpcTriggerController : MonoBehaviour
{
    [SerializeField] GameObject body;
    [SerializeField] float speed;
    [SerializeField] private CinemachineVirtualCamera _thisCamera;

    private GameObject _target;
    private CameraSwitcher _cameraSwitcher;

    private void Start()
    {
        _cameraSwitcher = CameraSwitcher.cameraSwitcher;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("충돌");
            _target = other.gameObject;
            _cameraSwitcher.SwitchPrioroty(_thisCamera);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("탈출");
            _target = other.gameObject;
            _cameraSwitcher.SwitchPrioroty(_thisCamera);
        }
    }

    void FollowTarget(GameObject target)
    {
        if (target.Equals(null))
        {
            Debug.Log("오브젝트가 없습니다!");
        }
        Vector3 targetVec3 = new Vector3(target.transform.position.x, gameObject.transform.position.y, target.transform.position.z) - transform.position;
        Quaternion targetRot = Quaternion.LookRotation(targetVec3);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * speed);
    }
}
