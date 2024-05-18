using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotationBoundaryDetection : MonoBehaviour
{
    public Transform swivelChair;
    public float rotationLimit = 90f; // Match the limit used in the rotation script
    public SpiralVirtualElevator virtualElevator;

    private float initialRotation;

    void Start()
    {
        initialRotation = swivelChair.localEulerAngles.y;
    }

    void Update()
    {
        // Calculate current rotation relative to the initial rotation
        float currentRotation = swivelChair.localEulerAngles.y;
        float rotationDelta = currentRotation - initialRotation;

        // Handle wrap-around values (if rotationDelta exceeds 180 or -180 degrees)
        if (rotationDelta > 180) rotationDelta -= 360;
        if (rotationDelta < -180) rotationDelta += 360;

        // Check if the user has reached the rotational limit
        if (Mathf.Abs(rotationDelta) >= rotationLimit)
        {
            ActivateVirtualElevator();
        }
    }

    void ActivateVirtualElevator()
    {
        // Activate the virtual elevator to indicate the need for reorientation
        virtualElevator.gameObject.SetActive(true);
        virtualElevator.StartSpiral();
    }
}