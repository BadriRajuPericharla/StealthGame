using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed=5f;
    [SerializeField]private float gravity=-10f;
    [SerializeField]private float jumpForce=4f;
    private float originalSpeed;
    public PlayerAnimations playerAnimations;
    private CharacterController controller;
    private float yvelocity;
    void Start()
    {
        controller=GetComponent<CharacterController>();
        originalSpeed=speed;
    }
    void Update()
    {
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        if(controller.isGrounded && yvelocity < 0f)
        {
            yvelocity=-2f;
            speed=originalSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            yvelocity=jumpForce;
            speed = originalSpeed*0.2f;
            playerAnimations.PlayJumpAnimation();
        }
    
        yvelocity+=gravity*Time.deltaTime;
        Vector3 movement=transform.right*horizontal+transform.forward*vertical;
        movement=movement.normalized;
        movement*=speed;
        movement.y=yvelocity;
        controller.Move(movement*Time.deltaTime);
        if(Mathf.Abs(vertical)>0.1f)
        {
            playerAnimations.PlayWalkAnimation();
        }
        else
        {
            playerAnimations.StopWalkAnimation();
        }
        if(horizontal<0)
        {
            playerAnimations.PlayWalkLeftAnimation();
        }
        else
        {
            playerAnimations.StopWalkLeftAnimation();
        }
        if (horizontal > 0)
        {
            playerAnimations.PlayWalkRightAnimation();
        }
        else
        {
            playerAnimations.StopWalkRightAnimation();
        }
    }
    

}
