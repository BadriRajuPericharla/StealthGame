using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0,360f*0.5f*Time.deltaTime,0);
    }
}
