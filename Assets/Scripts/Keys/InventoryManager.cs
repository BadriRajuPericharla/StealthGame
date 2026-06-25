using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<string> collectedDoorKeys=new List<string>();
    public List<string> collectedTreasureKeys=new List<string>();
    public void AddDoorKey(string KeyName)
    {
        if (!collectedDoorKeys.Contains(KeyName))
        {
            collectedDoorKeys.Add(KeyName);
        }
    }
    public void AddTreasureKey(string TreasureKeyName)
    {
        if (!collectedTreasureKeys.Contains(TreasureKeyName))
        {
            collectedTreasureKeys.Add(TreasureKeyName);
        }
    }
    public bool HasDoorKey(string KeyName)
    {
        return collectedDoorKeys.Contains(KeyName);
    }
    public bool HasTreasureKey(string TreasureKeyName)
    {
        return collectedTreasureKeys.Contains(TreasureKeyName);
    }
}
