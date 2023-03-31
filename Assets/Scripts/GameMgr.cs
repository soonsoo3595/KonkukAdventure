using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DataMgr.LoadData();
    }

    void Start()
    {
        Debug.Log(DataMgr.Buildings.data[0].name);
        Debug.Log(DataMgr.Departments.data[0].name);
        Debug.Log(DataMgr.Lectures.data[0].name);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
