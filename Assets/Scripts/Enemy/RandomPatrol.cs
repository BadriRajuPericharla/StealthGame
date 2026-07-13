using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    private static NavMeshTriangulation navMesh;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMesh.vertices == null || navMesh.vertices.Length == 0)
        {
            navMesh = NavMesh.CalculateTriangulation();
        }

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
        int randomIndex = Random.Range(0, navMesh.vertices.Length);
        navMeshAgent.SetDestination(navMesh.vertices[randomIndex]);
    }
}
