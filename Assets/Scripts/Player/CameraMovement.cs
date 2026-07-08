using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    float xRotation = 0f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX;
        float mouseY;
        mouseX = InputManager.LookX;
        mouseY = InputManager.LookY;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}

