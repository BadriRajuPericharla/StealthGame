using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLook : MonoBehaviour
{
    public static Vector2 lookInput;
    [SerializeField]private float sensitivity=0.2f;
    void Update()
    {
        lookInput = Vector2.zero;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.position.x > Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    lookInput = -touch.deltaPosition * sensitivity * Time.deltaTime;
                    break;
                }
            }
        }
    }
}
