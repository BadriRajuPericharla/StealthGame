using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeysClaiming : MonoBehaviour
{
    public InventoryManager inventory;
    public InventoryKeys inventoryKeys;
    public Keys keys;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DoorKey")
        {
            Debug.Log("Touched: " + other.name);
            for(int i = 0; i < keys.DoorKeyPrefab.Length; i++)
            {
                if (other.gameObject.name.Contains(keys.DoorKeyPrefab[i].name))
                {
                    inventory.AddDoorKey(keys.DoorKeyName[i]);
                    Color color=inventoryKeys.doorKeys[i].color;
                    color.a=1;
                    inventoryKeys.doorKeys[i].color=color;
                    other.gameObject.SetActive(false);
                    break;
                }
            }
        }
        if (other.gameObject.tag == "TreasureKey")
        {
            for(int i = 0; i < keys.TreasureKeyPrefab.Length; i++)
            {
                if (other.gameObject.name.Contains(keys.TreasureKeyPrefab[i].name))
                {
                    inventory.AddTreasureKey(keys.TreasureKeyName[i]);
                    Color color=inventoryKeys.treasureKeys[i].color;
                    color.a=1;
                    inventoryKeys.treasureKeys[i].color=color;
                    other.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }

}
