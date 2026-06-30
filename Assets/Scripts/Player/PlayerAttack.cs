using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerMovement player;
    public bool canAttack;
    void Start()
    {
        player=GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&canAttack)
        {
            player.playerAnimations.PlayAttackAnimation();
        }
        if (!canAttack)
        {
            return;
        }
    }
}
