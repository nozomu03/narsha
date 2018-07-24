using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPostiion = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPostiion;

        transform.LookAt(target);
    }
}
