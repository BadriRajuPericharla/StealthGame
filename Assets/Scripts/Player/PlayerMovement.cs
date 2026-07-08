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
    // [SerializeField]private float jumpForce=4f;
    private float originalSpeed;
    public PlayerAnimations playerAnimations;
    private CharacterController controller;
    public float timer;
    private float yvelocity;
    void Start()
    {
        controller=GetComponent<CharacterController>();
        originalSpeed=speed;
    }
    void Update()
    {
        float horizontal = InputManager.Horizontal;
        float vertical = InputManager.Vertical;
        // horizontal = Mathf.Clamp(horizontal, -1f, 1f);
        // vertical = Mathf.Clamp(vertical, -1f, 1f);
        if(controller.isGrounded && yvelocity < 0f)
        {
            yvelocity=-2f;
            timer=0f;
            speed=originalSpeed;
        }
        if (!controller.isGrounded)
        {
            timer+=Time.deltaTime;
        }
    
        yvelocity+=gravity*Time.deltaTime;
        Vector3 movement=transform.right*horizontal+transform.forward*vertical;
        movement=movement.normalized;
        movement*=speed;
        movement.y=yvelocity;
        controller.Move(movement*Time.deltaTime);
        if(Mathf.Abs(vertical)>0.1f|| MathF.Abs(horizontal)>0.01f)
        {
            playerAnimations.PlayWalkAnimation();
        }
        else
        {
            playerAnimations.StopWalkAnimation();
        }
    }
    

}
