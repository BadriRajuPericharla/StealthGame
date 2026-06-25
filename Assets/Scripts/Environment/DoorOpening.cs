using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorOpening : MonoBehaviour
{
    public Transform player;
    public InventoryManager inventory;
    public string RequiredKey;
    private bool isOpenDoor1 = false;
    bool hasOpened1=false;
    

    void Update()
    {
        float distance=Vector3.Distance(transform.position,player.transform.position);
        if(Input.GetKeyDown(KeyCode.R)  && !hasOpened1 && inventory.HasDoorKey(RequiredKey) && distance<5f)
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
