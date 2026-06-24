using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    private bool isOpenDoor1 = false;
    bool hasOpened1=false;
    public GameObject key1;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && key1!=null && !hasOpened1)
        {
            isOpenDoor1 = true;
            hasOpened1=true;
            Invoke("stopdoor",1f);
            
        }
        if (isOpenDoor1)
        {
            transform.Translate(Vector3.up * 3f * Time.deltaTime,Space.World);
        }
    }
    void stopdoor()
    {
        isOpenDoor1 =false;
    }
    void Door1()
    {
        
    }
}
