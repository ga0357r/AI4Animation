using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfStandardMovement : MonoBehaviour
{
    private float moveVertical = 0f;
    private float rotateHorizontal= 0f;
    private float forwardThrust = 0f;
    private float maxForwardVelocity = 0f;
    private float currentVelocity = 0f;
    private float torque = 0f;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rb;

    private void FixedUpdate()
    {
        moveVertical = Input.GetAxis("Vertical");
        rotateHorizontal = Input.GetAxis("Horizontal Rotation");
        Walk();
        Run();
        Rotate();
    }

    private void Walk()
    {
        if (moveVertical < 0)
            moveVertical = 0;

        if (moveVertical == 0)
        {
            anim.SetBool("IsWalking", false);
        }

        if (moveVertical > 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            maxForwardVelocity = 0.1f;
            forwardThrust = 7.5f;
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsRunning", false);
            Vector3 force = transform.forward * forwardThrust;
            currentVelocity = rb.velocity.sqrMagnitude;
            rb.AddForce(force, ForceMode.Force);

            if (currentVelocity >= maxForwardVelocity)
                rb.velocity = rb.velocity.normalized * maxForwardVelocity;
        }
    }

    private void Run()
    {
        if (moveVertical < 0)
            moveVertical = 0;

        if (moveVertical == 0)
        {
            anim.SetBool("IsRunning", false);
        }

        if (moveVertical > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            maxForwardVelocity = 1f;
            forwardThrust = 15f;
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsWalking", false);
            Vector3 force = transform.forward * forwardThrust;
            currentVelocity = rb.velocity.sqrMagnitude;
            rb.AddForce(force, ForceMode.Force);

            if (currentVelocity >= maxForwardVelocity)
                rb.velocity = rb.velocity.normalized * maxForwardVelocity;
        }
    }

    private void Rotate()
    {
        torque = 0.1f;
        if (rotateHorizontal != 0)
            transform.eulerAngles += transform.up * torque * rotateHorizontal;
    }
}
