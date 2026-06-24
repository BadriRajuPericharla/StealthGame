using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeysClaiming : MonoBehaviour
{
    public DoorOpening doorOpening;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DoorKey")
        {
            other.gameObject.SetActive(false);
            doorOpening.key1=other.gameObject;

        }
    }
}
