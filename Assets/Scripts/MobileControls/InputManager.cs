using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static float Horizontal;
    public static float Vertical;
    public static float LookX;
    public static float LookY;

    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private float touchSensitivity = 5f;
    [SerializeField] private float mouseSensitivity=100f;

    void Update()
    {
        if (Application.isMobilePlatform)
        {
            Horizontal = joystick.Horizontal;
            Vertical = joystick.Vertical;

            LookX = TouchLook.lookInput.x * touchSensitivity * Time.deltaTime;
            LookY = TouchLook.lookInput.y * touchSensitivity * Time.deltaTime;
        }
        else
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");

            LookX = Input.GetAxis("Mouse X")* mouseSensitivity * Time.deltaTime;
            LookY = Input.GetAxis("Mouse Y")* mouseSensitivity * Time.deltaTime;
        }
    }
}

