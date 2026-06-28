using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField]private Transform player;
    EnemyPatrol enemyPatrol;
    void Start()
    {
        enemyPatrol=GetComponent<EnemyPatrol>();
    }
    void Update()
    {
        Vector3 eyeposition=transform.position + Vector3.up*1.5f;
        Vector3 PlayerPosition=player.position+Vector3.up*1f;

        Vector3 directionToPlayer=PlayerPosition-eyeposition;
        
        float angle=Vector3.Angle(transform.forward,directionToPlayer);
        float distance=Vector3.Distance(transform.position,player.position);
        if (angle < 45 && distance<8f)
        {

            RaycastHit hit;
            
           if(Physics.Raycast(eyeposition,directionToPlayer.normalized,out hit, 8f))
            {
                if (hit.transform == player)
                {   
                    enemyPatrol.navMeshAgent.isStopped=false;
                    enemyPatrol.navMeshAgent.speed=4f;
                    enemyPatrol.navMeshAgent.SetDestination(player.position);
                    Debug.Log("Detected"); 
                    if (distance < 2f)
                    {
                        enemyPatrol.navMeshAgent.isStopped=true;
                        Debug.Log("attack");
                    }
            
                }
                
            }
            
        }
        if (enemyPatrol.gameObject!=null)
        {
            enemyPatrol.navMeshAgent.isStopped=false;
            enemyPatrol.navMeshAgent.speed=2f;
        }
        
    }
}
