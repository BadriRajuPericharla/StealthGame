using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysSpawner : MonoBehaviour
{
    public GameObject keysPrefabs;
    public Transform[] SpawnPoints;
    public int TotalKeys=7;
    void Awake()
    {
        for(int i = 0; i < TotalKeys; i++)
        {
            int RandomIndex=Random.Range(0,SpawnPoints.Length);
            Instantiate(keysPrefabs,SpawnPoints[RandomIndex].position,Quaternion.identity);
            SpawnPoints[RandomIndex]=SpawnPoints[SpawnPoints.Length-1];
            System.Array.Resize(ref SpawnPoints,SpawnPoints.Length-1);
        }
    }
}
