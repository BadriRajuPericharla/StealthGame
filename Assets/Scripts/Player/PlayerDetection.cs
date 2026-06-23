using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField]private Transform player;
    void Update()
    {
        Vector3 eyeposition=transform.position + Vector3.up*1.5f;
        Vector3 PlayerPosition=player.position+Vector3.up*1f;

        Vector3 directionToPlayer=PlayerPosition-eyeposition;
        
        float angle=Vector3.Angle(transform.forward,directionToPlayer);
        float distance=Vector3.Distance(transform.position,player.position);
        if (angle < 45 && distance<7f)
        {

            RaycastHit hit;
           if(Physics.Raycast(eyeposition,directionToPlayer.normalized,out hit, 7f))
            {
                if (hit.transform == player)
                {
                    Debug.Log("Detected");
                }
            }
        }
    }
}
