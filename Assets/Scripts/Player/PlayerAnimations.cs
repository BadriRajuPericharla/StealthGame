using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator playerAnimator;
    CharacterController characterController;
    void Start()
    {
        playerAnimator=GetComponent<Animator>();
        characterController=GetComponent<CharacterController>();
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
        characterController.enabled=false;
        playerAnimator.applyRootMotion=true;
        playerAnimator.SetTrigger("IsDie");
    }
}
