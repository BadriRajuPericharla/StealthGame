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
        Vector3 movement=new Vector3(horizontal,0f,vertical).normalized;
        movement*=speed;
        movement.y=yvelocity;
        controller.Move(movement*Time.deltaTime);
    }

}
