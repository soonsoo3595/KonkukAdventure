using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(120.8f,2f,129f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))this.transform.position = new Vector3(120.8f, 2f, 129f);
    }
}
