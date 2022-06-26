using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_Shot : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity;

    void Start()
    {
        // Get the rigidbody component and set the default velocity
        rb = GetComponent<Rigidbody>();
        rb.velocity = 60 * transform.forward;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // update the current velocity value
        velocity = rb.velocity;

        // Destroy the shell after 5 seconds
        Destroy(this.gameObject, 5);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Reflect the movement's velocity at the point of contact 
        ContactPoint contact = collision.contacts[0];
        rb.velocity = Vector3.Reflect(velocity, contact.normal);
    }

    
    
}
