using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 20f * Time.deltaTime, 0);
    }
}
