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
    Animator enemyAnimator;
    CapsuleCollider capsuleCollider;
    NavMeshAgent navMeshAgent;
    public float AttackRange=2f;
    public Transform PlayerPosition;
    void Start()
    {
        enemyAnimator=GetComponent<Animator>();
        capsuleCollider=GetComponent<CapsuleCollider>();
        navMeshAgent=GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        float distance=Vector3.Distance(transform.position,PlayerPosition.transform.position);
        if(distance<AttackRange && Input.GetMouseButton(0))
        {
            enemyAnimator.applyRootMotion=true;
            capsuleCollider.enabled=false;
            navMeshAgent.enabled=false;
            StartCoroutine(Death());
            Debug.Log("died");
        }
    }
    IEnumerator Death()
    {
        enemyAnimator.SetBool("IsDie",true);
        SpotLigth.SetActive(false);
        key.transform.parent=null;
        yield return new WaitForSeconds(2f);
        key.SetActive(true);
        Destroy(gameObject);
    }
}
