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
    void Update()
    {
        int layerMask=~ LayerMask.GetMask("Player");
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, claimDistance,layerMask))
        {
            
            Debug.Log("Touched: " + hit.collider.name);
            if (hit.collider.CompareTag("DoorKey")&&Input.GetKeyDown(KeyCode.C))
            {
                // Pick up the door key
                
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
            else if (hit.collider.CompareTag("TreasureKey")&&Input.GetKeyDown(KeyCode.C))
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
            else if (hit.collider.CompareTag("TreasureChest") && Input.GetKeyDown(KeyCode.E))
            {
                canOpenTreasure=true;
            }
            else if (hit.collider.CompareTag("Enemy") && Input.GetMouseButtonDown(0))
            {
                enemyDetected=true;
            }
        }
    

    }

}
