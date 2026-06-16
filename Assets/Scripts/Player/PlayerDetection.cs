using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField]private Transform player;
    void Update()
    {
        Vector3 directionToPlayer=player.position-transform.position;
        float angle=Vector3.Angle(transform.forward,directionToPlayer);
        float distance=Vector3.Distance(transform.position,player.position);
        if (angle < 30 && distance<10f)
        {
            Debug.Log("detected");
        }
    }
}
