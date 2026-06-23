using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isOpen = true;
            Invoke("stopdoor",1f);
        }

        if (isOpen)
        {
            transform.Translate(Vector3.up * 3f * Time.deltaTime,Space.World);
        }
    }
    void stopdoor()
    {
        isOpen =false;
    }
}
