using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralVirtualElevator : MonoBehaviour
{
    public Transform swivelChair;
    public Transform vrHead;
    public float rotationAngle = 180f; // The angle to rotate the user
    public float spiralHeight = 1.0f; // The vertical distance to move the user
    public float spiralDuration = 2.0f; // Duration of the spiral motion

    private float elapsedTime = 0f;
    private bool isSpiraling = false;
    private Vector3 startPosition;

    void Update()
    {
        if (isSpiraling)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / spiralDuration;

            // Calculate spiral movement
            float currentAngle = Mathf.Lerp(0, rotationAngle, t);
            float currentHeight = Mathf.Lerp(0, spiralHeight, t);

            swivelChair.localEulerAngles = new Vector3(0, currentAngle, 0);
            vrHead.localEulerAngles = new Vector3(0, currentAngle, 0);
            vrHead.localPosition = startPosition + new Vector3(0, currentHeight, 0);

            if (elapsedTime >= spiralDuration)
            {
                isSpiraling = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void StartSpiral()
    {
        isSpiraling = true;
        elapsedTime = 0f;
        startPosition = vrHead.localPosition;
    }
}