using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureOpening : MonoBehaviour
{
    public Keys keys;
    public GameObject player;
    public float ClaimRange=3f;
    public InventoryManager inventoryManager;
    public string[] RequiredKeyNames;
    bool allKeysCollected;
    void Update()
    {
        float distance=Vector3.Distance(transform.position,player.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance<ClaimRange)
        {
            allKeysCollected=true;
            for(int i = 0; i < RequiredKeyNames.Length; i++)
            {
                
                if (!inventoryManager.HasTreasureKey(RequiredKeyNames[i]))
                {
                    allKeysCollected=false;
                    break;
                }
                if (allKeysCollected)
                {
                    Debug.Log("Win");
                }
            }
        }
    }
}
