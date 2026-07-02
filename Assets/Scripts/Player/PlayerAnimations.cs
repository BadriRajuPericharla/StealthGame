using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator playerAnimator;
    CharacterController characterController;
    PlayerAttack playerAttack;
    PlayerMovement playerMovement;
    void Start()
    {
        playerAnimator=GetComponent<Animator>();
        characterController=GetComponent<CharacterController>();
        playerMovement=GetComponent<PlayerMovement>();
        playerAttack=GetComponent<PlayerAttack>();
    }
    public void PlayWalkAnimation()
    {
        playerAnimator.SetBool("IsWalk",true);
    }
    public void StopWalkAnimation()
    {
        playerAnimator.SetBool("IsWalk",false);
    }
    public void PlayAttackAnimation()
    {
        playerAnimator.SetTrigger("IsAttack");
    }
    public void PlayDeathAnimation()
    {
        playerAttack.enabled=false;
        playerMovement.enabled=false;
        characterController.enabled=false;
        playerAnimator.applyRootMotion=true;
        playerAnimator.SetTrigger("IsDie");
    }
    public void PlayWalkLeftAnimation()
    {
        playerAnimator.SetBool("LeftWalk",true);
    }
    public void StopWalkLeftAnimation()
    {
        playerAnimator.SetBool("LeftWalk",false);
    }
    public void PlayWalkRightAnimation()
    {
        playerAnimator.SetBool("RigthWalk",true);
    }
    public void StopWalkRightAnimation()
    {
        playerAnimator.SetBool("RigthWalk",false);
    }
    public void PlayJumpAnimation()
    {
        playerAnimator.SetTrigger("IsJump");
    }
}
