using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (navMeshAgent.isActiveAndEnabled)
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5)
            {
                RandomPatroling();
            }
        }
        
    }
    public void RandomPatroling()
    {
        NavMeshTriangulation navMesh=NavMesh.CalculateTriangulation();
        int randomIndex=Random.Range(0,navMesh.vertices.Length);
        navMeshAgent.SetDestination(navMesh.vertices[randomIndex]);
    }
}
