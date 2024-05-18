using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LimitedSwivelChairRotation : MonoBehaviour
{
    public Transform vrHead;
    public Transform swivelChair;
    public float rotationGainFactor = 1.05f;
    public float rotationLimit = 90f; // Maximum rotation in either direction from the starting point

    private float initialRotation;
    private float cumulativeRotation;

    void Start()
    {
        initialRotation = swivelChair.localEulerAngles.y;
        cumulativeRotation = 0f;
    }

    void Update()
    {
        // Calculate the change in rotation
        float currentRotation = swivelChair.localEulerAngles.y;
        float rotationDelta = currentRotation - initialRotation;

        // Handle wrap-around values (if rotationDelta exceeds 180 or -180 degrees)
        if (rotationDelta > 180) rotationDelta -= 360;
        if (rotationDelta < -180) rotationDelta += 360;

        // Apply a small rotational gain
        rotationDelta *= rotationGainFactor;

        // Update cumulative rotation
        cumulativeRotation += rotationDelta;

        // Clamp the cumulative rotation within the limit
        cumulativeRotation = Mathf.Clamp(cumulativeRotation, -rotationLimit, rotationLimit);

        // Rotate the VR headset
        vrHead.Rotate(0, rotationDelta, 0);

        // Update initial rotation for the next frame
        initialRotation = currentRotation;
    }
}

