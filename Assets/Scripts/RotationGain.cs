using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGain : MonoBehaviour
{
    public Transform vrHead;
    public float rotationGainFactor = 1.05f;

    void Update()
    {
        // Apply a small rotational gain to the VR headset's rotation
        Vector3 headRotation = vrHead.localEulerAngles;
        headRotation.y *= rotationGainFactor;
        vrHead.localEulerAngles = headRotation;
    }
}