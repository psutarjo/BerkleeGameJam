using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity.Set(0, rb.velocity.y, 0);

        if (Input.GetKey(KeyCode.W)) {
            rb.velocity += transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S)) {
            rb.velocity -= transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.A)) {
            rb.velocity += (Quaternion.Euler(0, -90, 0)*transform.forward) * speed;
        }
        if (Input.GetKey(KeyCode.D)) {
            rb.velocity += (Quaternion.Euler(0, 90, 0) * transform.forward) * speed;
        }
    }
}
