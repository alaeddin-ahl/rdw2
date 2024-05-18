using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedirectedWalking : MonoBehaviour
{
    public Transform vrHead;
    public float curvatureRadius = 10.0f;
    public float boundaryDistance = 1.0f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        initialPosition = vrHead.position;
        initialRotation = vrHead.rotation;
    }

    void Update()
    {
        // Calculate the distance from the initial position
        Vector3 offset = vrHead.position - initialPosition;
        float distance = offset.magnitude;

        // Calculate the curvature gain
        float curvatureGain = Mathf.Atan2(offset.x, offset.z) / curvatureRadius;

        Debug.Log("distance:" +distance + " boundaryDistance:"+boundaryDistance);

        // Check if the user is near the boundary
        if (distance > boundaryDistance)
        {

            // Apply the curvature gain
            Vector3 newDirection = Quaternion.Euler(0, curvatureGain, 0) * offset.normalized;
            vrHead.position = initialPosition + newDirection * distance;
        }

        // Apply a small rotation gain
        Vector3 headRotation = vrHead.localEulerAngles;
        headRotation.y += curvatureGain;
        vrHead.localEulerAngles = headRotation;
    }
}
