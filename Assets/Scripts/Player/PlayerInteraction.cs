using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public InventoryManager inventory;
    public InventoryKeys inventoryKeys;
    [SerializeField]private float claimDistance=3f;
    public Keys keys;
    public RaycastHit hit;
    public bool canOpenTreasure=false;
    public bool enemyDetected=false;
    public static bool canOpenDoor=false;
    void Update()
    {
        int layerMask=~ LayerMask.GetMask("Player");
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, claimDistance,layerMask))
        {
            if (Application.isMobilePlatform)
            {
                if (hit.collider.CompareTag("DoorKey") || hit.collider.CompareTag("TreasureKey")||hit.collider.CompareTag("TreasureChest"))
                {
                    UiManager.Instance.ShowClaimButton();
                }
                else if (hit.collider.CompareTag("Door"))
                {
                    UiManager.Instance.ShowDoorOpenButton();
                }
                else
                {
                    UiManager.Instance.CloseDoorOpenButton();
                    UiManager.Instance.CloseCliamButton();
                }
                
            }
            
            Debug.Log("Touched: " + hit.collider.name);

            KeysClaimimg();
        }
        else if(Application.isMobilePlatform)
        {
            UiManager.Instance.CloseCliamButton();
            UiManager.Instance.CloseDoorOpenButton();
        }
    }
    public void KeysClaimimg()
    {
        if (hit.collider.CompareTag("DoorKey")&&InputManager.interact)
        {

                
            for(int i = 0; i < keys.DoorKeyPrefab.Length; i++)
            {
                if (hit.collider.gameObject.name.Contains(keys.DoorKeyPrefab[i].name))
                {
                    inventory.AddDoorKey(keys.DoorKeyName[i]);
                    Color color=inventoryKeys.doorKeys[i].color;
                    color.a=1;
                    inventoryKeys.doorKeys[i].color=color;
                    hit.collider.gameObject.SetActive(false);
                    break;
                }
            }
        }
        else if (hit.collider.CompareTag("TreasureKey")&&InputManager.interact)
        {
            for(int i = 0; i < keys.TreasureKeyPrefab.Length; i++)
            {
                if (hit.collider.gameObject.name.Contains(keys.TreasureKeyPrefab[i].name))
                {
                    inventory.AddTreasureKey(keys.TreasureKeyName[i]);
                    Color color=inventoryKeys.treasureKeys[i].color;
                    color.a=1;
                    inventoryKeys.treasureKeys[i].color=color;
                    hit.collider.gameObject.SetActive(false);
                    break;
                }
            }
        }
        else if (hit.collider.CompareTag("TreasureChest") && InputManager.treasureInteract)
        {
            canOpenTreasure=true;
        }
        else if (hit.collider.CompareTag("Enemy") && InputManager.interact)
        {
            enemyDetected=true;
        }
        else if(hit.collider.CompareTag("Door") && InputManager.doorOpen)
        {
            canOpenDoor=true;
        }
    }
}


