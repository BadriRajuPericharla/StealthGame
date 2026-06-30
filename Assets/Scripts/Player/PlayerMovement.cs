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
    public PlayerAnimations playerAnimations;
    private CharacterController controller;
    private float yvelocity;
    void Start()
    {
        controller=GetComponent<CharacterController>();
    }
    void Update()
    {
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        if(controller.isGrounded && yvelocity < 0f)
        {
            yvelocity=-2f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            yvelocity=jumpForce;
        }
        yvelocity+=gravity*Time.deltaTime;
        Vector3 movement=transform.right*horizontal+transform.forward*vertical;
        movement.Normalize();
        movement*=speed;
        movement.y=yvelocity;
        controller.Move(movement*Time.deltaTime);
        if(Mathf.Abs(horizontal)>0.1f||Mathf.Abs(vertical)>0.1f)
        {
            playerAnimations.PlayWalkAnimation();
        }
        else
        {
            playerAnimations.StopWalkAnimation();
        }
    }
    

}
