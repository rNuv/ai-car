using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 50.0f;
    private float turnSpeed = 50.0f;

    // Update is called once per frame
    void Update()
    {
        SetInputs(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }

    public void SetInputs(float forwardAmount, float turnAmount)
    {
        transform.Translate(Vector3.forward * forwardAmount * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, turnAmount * turnSpeed * Time.deltaTime);
    }

    public void StopCompletely()
    {
        SetInputs(0f, 0f);
    }
}
