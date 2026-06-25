using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="TreasureKey",menuName ="Keys")]
public class Keys : ScriptableObject
{
    public string[] DoorKeyName;
    public GameObject[] DoorKeyPrefab;
    public string[] TreasureKeyName;
    public GameObject[] TreasureKeyPrefab;

}
