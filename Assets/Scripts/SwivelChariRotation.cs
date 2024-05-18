using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwivelChairRotation : MonoBehaviour
{
    public Transform vrHead;
    public Transform swivelChair;
    public float rotationGainFactor = 1.05f;

    private float previousRotation;

    void Start()
    {
        previousRotation = swivelChair.localEulerAngles.y;
    }

    void Update()
    {
        // Calculate the change in rotation
        float currentRotation = swivelChair.localEulerAngles.y;
        float rotationDelta = currentRotation - previousRotation;

        // Apply a small rotational gain
        rotationDelta *= rotationGainFactor;

        // Rotate the VR headset
        vrHead.Rotate(0, rotationDelta, 0);

        // Update previous rotation
        previousRotation = currentRotation;
    }
}