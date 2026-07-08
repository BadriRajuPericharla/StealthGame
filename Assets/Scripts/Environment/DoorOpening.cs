using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorOpening : MonoBehaviour
{
    public Transform player;
    public InventoryManager inventory;
    public string RequiredKey;
    [SerializeField]private MessageText messageText;
    private bool isOpenDoor1 = false;
    bool hasOpened1=false;
    

    void Update()
    {
        float distance=Vector3.Distance(transform.position,player.transform.position);
        if(InputManager.doorOpen  && !hasOpened1 && inventory.HasDoorKey(RequiredKey) && distance<4f&&PlayerInteraction.canOpenDoor)
        {
            UiManager.Instance.CloseDoorOpenButton();
            isOpenDoor1 = true;
            hasOpened1=true;
            Invoke("stopdoor",1f);
            
        }
        if(InputManager.doorOpen && !inventory.HasDoorKey(RequiredKey) && distance<4f)
        {
            messageText.KeyCollectMessage();
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
}
