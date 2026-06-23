using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public GameObject key;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            key.transform.parent=null;
            key.SetActive(true);
            Destroy(hit.gameObject);
            Debug.Log("Collided");
        }
    }
}
