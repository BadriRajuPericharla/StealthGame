using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class KeysClaiming : MonoBehaviour
{
    public InventoryManager inventory;
    public InventoryKeys inventoryKeys;
    [SerializeField]private CinemachineVirtualCamera followCamera;
    [SerializeField]private float claimDistance=3f;
    public Keys keys;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            KeyPickUp();
        }
    }
    public void KeyPickUp()
    {
        int layerMask=~ LayerMask.GetMask("Player");
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, claimDistance,layerMask))
        {
            Debug.Log("Hit: " + hit.collider.name);

            if (hit.collider.CompareTag("DoorKey"))
            {
                // Pick up the door key
                Debug.Log("Touched: " + hit.collider.name);
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
            else if (hit.collider.CompareTag("TreasureKey"))
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
        }
    }

}
