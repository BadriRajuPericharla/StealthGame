using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator playerAnimator;
    CharacterController characterController;
    PlayerMovement playerMovement;
    void Start()
    {
        playerAnimator=GetComponent<Animator>();
        characterController=GetComponent<CharacterController>();
        playerMovement=GetComponent<PlayerMovement>();
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
        playerMovement.enabled=false;
        characterController.enabled=false;
        playerAnimator.applyRootMotion=true;
        playerAnimator.SetTrigger("IsDie");
    }
}
