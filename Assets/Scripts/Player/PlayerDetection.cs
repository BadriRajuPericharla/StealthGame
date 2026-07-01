using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private PlayerAttack playerAttack;
    bool enemyDetectedPlayer=false;
    bool hasAttacked=false;
    EnemyPatrol enemyPatrol;
    EnemyAnimations enemyAnimations;
    void Start()
    {
        enemyPatrol=GetComponent<EnemyPatrol>();
        enemyAnimations=GetComponent<EnemyAnimations>();
    }
    void Update()
    {
        if (!enemyPatrol.navMeshAgent.isActiveAndEnabled)
            return;
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
                    if (!enemyDetectedPlayer)
                    {
                        enemyDetectedPlayer=true;
                        EnemyManager.Instance.EnemyDetectedPlayer();

                    }
                    enemyPatrol.navMeshAgent.isStopped=false;
                    enemyPatrol.navMeshAgent.speed=4f;
                    enemyPatrol.navMeshAgent.SetDestination(player.position);
                    Debug.Log("Detected"); 
                    if (distance < 2f)
                    {
                        if (!hasAttacked)
                        {
                            hasAttacked=true;
                            enemyPatrol.navMeshAgent.isStopped=true;
                            playerAttack.enabled=false;
                            enemyAnimations.PlayAttackAnimation();
                            playerMovement.playerAnimations.PlayDeathAnimation();
                            StartCoroutine(GameOver());
                            Debug.Log("attack");
                        }
                        

                    }
                    else
                    {
                        enemyPatrol.navMeshAgent.isStopped=false;
                    }
            
                }
                
            }
            
        }
        else
        {
            if (enemyDetectedPlayer)
            {
                enemyDetectedPlayer = false;
                EnemyManager.Instance.EnemyLostPlayer();
            }
            enemyPatrol.navMeshAgent.isStopped=false;
            enemyPatrol.navMeshAgent.speed=2f;
        }
        
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        UiManager.Instance.ShowGameOver();
    }
}
