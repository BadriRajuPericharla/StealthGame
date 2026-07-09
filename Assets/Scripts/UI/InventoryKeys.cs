using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryKeys : MonoBehaviour
{
    public  Image[] treasureKeys;
    public  Image[] doorKeys;
    void Start()
    {
        for(int i = 0; i < treasureKeys.Length; i++)
        {
            Color color=treasureKeys[i].color;
            color.a=0.1f;
            treasureKeys[i].color=color;
        }
        for(int i = 0; i < doorKeys.Length; i++)
        {
            Color color=doorKeys[i].color;
            color.a=0.1f;
            doorKeys[i].color=color;
        }
    }
}
