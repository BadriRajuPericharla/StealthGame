using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static float Horizontal;
    public static float Vertical;
    public static float LookX;
    public static float LookY;
    public static bool interact;
    public static bool treasureInteract;
    public static bool attack;
    public static bool doorOpen;

    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private float touchSensitivity = 5f;
    [SerializeField] private float mouseSensitivity=100f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            interact=true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            treasureInteract=true;
        }
        if (!Application.isMobilePlatform)
        {
            if (Input.GetMouseButtonDown(0))
            {
                attack=true;
            }
        }
        if (!Application.isMobilePlatform)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                doorOpen=true;
            }
        }
        
        
        if (Application.isMobilePlatform)
        {
            UiManager.Instance.ShowMobileControls();
            Horizontal = joystick.Horizontal;
            Vertical = joystick.Vertical;
            LookX = TouchLook.lookInput.x * touchSensitivity * Time.deltaTime;
            LookY = TouchLook.lookInput.y * touchSensitivity * Time.deltaTime;
        }
        else
        {
            UiManager.Instance.CloseMobileControls();
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
            LookX = Input.GetAxis("Mouse X")* mouseSensitivity * Time.deltaTime;
            LookY = Input.GetAxis("Mouse Y")* mouseSensitivity * Time.deltaTime;
        }
    }
    public void mobileInteract()
    {
        interact=true;
    }
    public void TreasureInteract()
    {
        treasureInteract=true;
    }
    public void mobileAttack()
    {
        attack=true;
    }
    public void DoorOpen()
    {
        doorOpen=true;
    }
    void LateUpdate()
    {
        interact=false;
        attack=false;
        doorOpen=false;
        treasureInteract=false;
    }
}

