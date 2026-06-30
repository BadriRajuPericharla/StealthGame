using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private PlayerAttack playerAttack;
    [SerializeField]private CameraMovement cameraMovement;
    [SerializeField]private KeysClaiming keysClaiming;
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
                    if (distance < 2f&&!hasAttacked)
                    {
                        hasAttacked=true;
                        enemyPatrol.navMeshAgent.isStopped=true;
                        enemyAnimations.PlayAttackAnimation();
                        PlayerDie();
                        StartCoroutine(GameOver());
                        Debug.Log("attack");

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
            enemyPatrol.navMeshAgent.isStopped=false;
            enemyPatrol.navMeshAgent.speed=2f;
        }
        
    }
    public void PlayerDie()
    {
        playerMovement.playerAnimations.PlayDeathAnimation();
        playerMovement.enabled=false;
        playerAttack.enabled=false;
        cameraMovement.enabled=false;
        keysClaiming.enabled=false;
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        UiManager.instance.ShowGameOver();
    }
}
