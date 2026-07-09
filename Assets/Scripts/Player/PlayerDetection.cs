using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private PlayerAttack playerAttack;
    [SerializeField]private GameObject deathCam;
    [SerializeField]private GameObject globalVolume;
    bool enemyDetectedPlayer=false;
    NavMeshAgent navMeshAgent;
    bool hasAttacked=false;
    EnemyAnimations enemyAnimations;
    void Start()
    {
        navMeshAgent=GetComponent<NavMeshAgent>();
        enemyAnimations=GetComponent<EnemyAnimations>();
    }
    void Update()
    {
        if (!navMeshAgent.isActiveAndEnabled)
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
                        globalVolume.SetActive(true);
                        EnemyManager.Instance.EnemyDetectedPlayer();

                    }
                    
                    navMeshAgent.isStopped=false;
                    navMeshAgent.speed=4f;
                    
                    navMeshAgent.SetDestination(player.position);
                    Debug.Log("Detected"); 
                    if (distance < 2f)
                    {
                        if (!hasAttacked)
                        {
                            hasAttacked=true;
                            navMeshAgent.isStopped=true;
                            playerAttack.enabled=false;
                            enemyAnimations.PlayAttackAnimation();
                            deathCam.SetActive(true);
                            playerMovement.playerAnimations.PlayDeathAnimation();
                            StartCoroutine(GameOver());
                            Debug.Log("attack");
                        }
                        

                    }
                    else
                    {
                        navMeshAgent.isStopped=false;
                    }
            
                }
                
            }
            
        }
        else
        {
            if (enemyDetectedPlayer)
            {
                enemyDetectedPlayer = false;
                navMeshAgent.isStopped=false;
                globalVolume.SetActive(false);
                EnemyManager.Instance.EnemyLostPlayer();
            }
            
            navMeshAgent.speed=2f;
        }
        
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        AudioManager.instance.PlayEnemyAttack();
        yield return new WaitForSeconds(1.5f);
        UiManager.Instance.ShowGameOver();
    }
}
