using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TranslationGain : MonoBehaviour
{
    public Transform vrHead;
    public float translationGainFactor = 1.05f;

    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = vrHead.position;
    }

    void Update()
    {
        // Calculate the translation gain
        Vector3 currentPosition = vrHead.position;
        Vector3 deltaPosition = currentPosition - previousPosition;
        deltaPosition *= translationGainFactor;

        // Apply the translation gain
        vrHead.position = previousPosition + deltaPosition;
        previousPosition = currentPosition;
    }
}