using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    public int detectedEnemies=0;
    void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void EnemyDetectedPlayer()
    {
        detectedEnemies++;
    }
    public void EnemyLostPlayer()
    {
        detectedEnemies--;
    }
}
