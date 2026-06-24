using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerMovement player;
    Animator playerAnimator;
    void Start()
    {
        player=GetComponent<PlayerMovement>();
        playerAnimator=player.PlayerAnimator;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnimator.SetBool("IsAttack",true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            playerAnimator.SetBool("IsAttack",false);
        }
    }
}
