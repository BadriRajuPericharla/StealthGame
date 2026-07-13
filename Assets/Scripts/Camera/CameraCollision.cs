using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private LayerMask obstacleLayer;
    [SerializeField]private float sphereRadius=0.3f;
    [SerializeField]private float smoothSpeed=10f;
    private Vector3 defaultLocalPosition;
    void Start()
    {
        defaultLocalPosition=transform.localPosition;
    }
    void LateUpdate()
    {
        Vector3 defaultWorldPosition=player.TransformPoint(defaultLocalPosition);
        Vector3 direction=defaultWorldPosition-player.position;
        float distance=direction.magnitude;
        RaycastHit hit;
        if(Physics.SphereCast(player.position,sphereRadius,direction.normalized,out hit, distance, obstacleLayer))
        {
            Vector3 localHitPosition=player.InverseTransformPoint(player.position+direction.normalized*(hit.distance-sphereRadius));
            transform.localPosition=Vector3.Lerp(transform.localPosition,localHitPosition,smoothSpeed*Time.deltaTime);
        }
        else
        {
            transform.localPosition=Vector3.Lerp(transform.localPosition,defaultLocalPosition,smoothSpeed*Time.deltaTime);
        }
    }
}
