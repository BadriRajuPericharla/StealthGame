using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerMovement player;
    
    void Start()
    {
        player=GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (EnemyManager.Instance.detectedEnemies > 0)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) && EnemyManager.Instance.detectedEnemies==0)
        {
            player.playerAnimations.PlayAttackAnimation();
        }
        
    }
}
