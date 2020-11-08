using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConrollerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    Vector3 gVelocity;

    public float g = 9.8f;

    public Transform groundChecker;
    public float groundBuffer = 0.4f;
    public LayerMask groundMask;

    private bool grounded;
    
    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundChecker.position, groundBuffer, groundMask);
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        move *= speed * Time.deltaTime;

        controller.Move(move);
        
        gVelocity.y -= g * Time.deltaTime;
        
        if (grounded && gVelocity.y <= 0) {
            gVelocity.y = -0.1f;
        }
        
        controller.Move(gVelocity * Time.deltaTime);
    }
}
