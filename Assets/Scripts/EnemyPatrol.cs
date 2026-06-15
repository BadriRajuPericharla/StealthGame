using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    [SerializeField]private Transform player;
    private NavMeshAgent navMeshAgent;
    bool goingToB=false;
    void Start()
    {
        navMeshAgent=GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(PointA.position);
    }
    void Update()
    {
        if(!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.2f)
        {
            if (goingToB)
            {
                navMeshAgent.SetDestination(PointB.position);
            }
            else
            {
                navMeshAgent.SetDestination(PointA.position);
            }
            goingToB=!goingToB;
        }
        DetectPlayer();
    }
    void DetectPlayer()
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
