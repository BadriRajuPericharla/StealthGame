using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public NavMeshAgent navMeshAgent;
    bool goingToB=false;
    void Start()
    {
        navMeshAgent=GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(PointA.position);
    }
    void Update()
    {
        if (navMeshAgent.isActiveAndEnabled)
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
        }
        
        
    }
    
}
