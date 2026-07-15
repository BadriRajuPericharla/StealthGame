using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static float Horizontal;
    public static float Vertical;
    public static float LookX;
    public static float LookY;
    public static bool interact=false;
    public static bool treasureInteract=false;
    public static bool attack=false;
    public static bool doorOpen=false;

    [SerializeField] private VariableJoystick joystick;
    [SerializeField]private Slider sensitivitySlider;
    [SerializeField] private float touchSensitivity = 5f;
    [SerializeField] private float mouseSensitivity=400f;


    void Start()
    {
        if (!Application.isMobilePlatform)
        {
            float sensitivity=PlayerPrefs.GetFloat("MouseSens",mouseSensitivity);
            mouseSensitivity=sensitivity;
            sensitivitySlider.minValue=100;
            sensitivitySlider.maxValue=400;
            sensitivitySlider.value=mouseSensitivity;
            sensitivitySlider.onValueChanged.AddListener(MouseSensitivity);
        }
        else
        {
            float sensitivity=PlayerPrefs.GetFloat("TouchSens",touchSensitivity);
            touchSensitivity=sensitivity;
            sensitivitySlider.minValue=4;
            sensitivitySlider.maxValue=18;
            sensitivitySlider.value=touchSensitivity;
            sensitivitySlider.onValueChanged.AddListener(TouchSensitivity);
            
        }
    }
    void Update()
    {
        if (!Application.isMobilePlatform)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                doorOpen=true;
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                interact=true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                treasureInteract=true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                attack=true;
            }
        }
        
        
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
    public void mobileInteract()
    {
        interact=true;
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
    public void MouseSensitivity(float value)
    {
        mouseSensitivity=value;
        PlayerPrefs.SetFloat("MouseSens",value);
        PlayerPrefs.Save();
    }
    public void TouchSensitivity(float value)
    {
        touchSensitivity=value;
        PlayerPrefs.SetFloat("TouchSens",value);
        PlayerPrefs.Save();
    }
    void LateUpdate()
    {
        interact=false;
        attack=false;
        doorOpen=false;
        treasureInteract=false;
    }
}

