using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysSpawner : MonoBehaviour
{
    public GameObject[] keysPrefabs;
    public Transform[] SpawnPoints;
    void Awake()
    {
        for(int i = 0; i < keysPrefabs.Length; i++)
        {
            int RandomIndex=Random.Range(0,SpawnPoints.Length);
            Instantiate(keysPrefabs[i],SpawnPoints[RandomIndex].position,Quaternion.identity);
            SpawnPoints[RandomIndex]=SpawnPoints[SpawnPoints.Length-1];
            System.Array.Resize(ref SpawnPoints,SpawnPoints.Length-1);
        }
    }
}
