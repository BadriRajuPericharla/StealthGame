using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDie : MonoBehaviour
{
    public GameObject key;
    public float AttackRange=2f;
    public Transform PlayerPosition;
    void Update()
    {
        float distance=Vector3.Distance(transform.position,PlayerPosition.transform.position);
        if(distance<AttackRange && Input.GetMouseButton(0))
        {
            key.transform.parent=null;
            key.SetActive(true);
            Destroy(gameObject);
            Debug.Log("died");
        }
    }
}
