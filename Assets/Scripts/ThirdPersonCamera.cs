using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float smooth = 3f;
    public Transform standardPos;
    public Transform player;

    void Start()
    {
        transform.position = standardPos.position;
        transform.forward = standardPos.forward;
    }

    void FixedUpdate()
    {
        setCameraPositionNormalView();  
    }

    void setCameraPositionNormalView()
    {
        transform.position = Vector3.Lerp(transform.position, standardPos.position, Time.deltaTime * smooth);
        transform.forward = Vector3.Lerp(transform.forward, standardPos.forward, Time.deltaTime * smooth);
    }
}
