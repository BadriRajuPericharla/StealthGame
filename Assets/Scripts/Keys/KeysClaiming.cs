using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysClaiming : MonoBehaviour
{
    public InventoryManager inventory;
    public Keys keys;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DoorKey")
        {
            for(int i = 0; i < keys.DoorKeyPrefab.Length; i++)
            {
                if (other.gameObject.name.Contains(keys.DoorKeyPrefab[i].name))
                {
                    inventory.AddDoorKey(keys.DoorKeyName[i]);
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
                    inventory.AddDoorKey(keys.TreasureKeyName[i]);
                    other.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
}
