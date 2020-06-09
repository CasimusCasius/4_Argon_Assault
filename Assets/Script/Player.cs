using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [Tooltip("ms^-1")][SerializeField] float speed=50f;
    [Tooltip("m")] [SerializeField] float xClamp = 25f;
    [Tooltip("m")] [SerializeField] float yClamp = 16f;
    [SerializeField] float pitchPosFactor = -0.75f;
    [SerializeField] float pitchControlFactor = -10f;
    [SerializeField] float yawPosFactor = 1f;
    [SerializeField] float rollControlFactor = -25f;
    float xThrow;
    float yThrow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * pitchPosFactor + yThrow * pitchControlFactor;
        float yaw = transform.localPosition.x * yawPosFactor;
        float roll = xThrow* rollControlFactor;


        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;
        float xNewPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xClamp, xClamp);

        yThrow = Input.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;
        float yNewPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yClamp, yClamp);
        transform.localPosition = new Vector3(xNewPos, yNewPos, transform.localPosition.z);
    }
}
