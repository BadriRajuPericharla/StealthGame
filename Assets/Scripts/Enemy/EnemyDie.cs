using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyDie : MonoBehaviour
{
    public GameObject key;
    public GameObject SpotLigth;
    EnemyAnimations enemyAnimations;
    CapsuleCollider capsuleCollider;
    NavMeshAgent navMeshAgent;
    PlayerDetection playerDetection;
    public float AttackRange=2f;
    public Transform PlayerPosition;
    void Start()
    {
        enemyAnimations=GetComponent<EnemyAnimations>();
        capsuleCollider=GetComponent<CapsuleCollider>();
        navMeshAgent=GetComponent<NavMeshAgent>();
        playerDetection=GetComponent<PlayerDetection>();
    }
    void Update()
    {
        float distance=Vector3.Distance(transform.position,PlayerPosition.transform.position);
        if(distance<AttackRange && Input.GetMouseButton(0))
        {
            enemyAnimations.enemyAnimator.applyRootMotion=true;
            capsuleCollider.enabled=false;
            navMeshAgent.enabled=false;
            playerDetection.enabled=false;
            StartCoroutine(Death());
            Debug.Log("died");
        }
    }
    IEnumerator Death()
    {
        enemyAnimations.PlayDeathAnimation();
        SpotLigth.SetActive(false);
        if (key != null)
        {
            key.transform.parent=null;
        }
        yield return new WaitForSeconds(2f);
        if (key != null)
        {
            key.SetActive(true);
        }
        
        Destroy(gameObject);
    }
}
