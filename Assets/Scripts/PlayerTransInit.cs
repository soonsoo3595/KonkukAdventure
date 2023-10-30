using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransInit : MonoBehaviour
{
    public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = spawn.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))this.transform.position = spawn.transform.position;
    }
}
