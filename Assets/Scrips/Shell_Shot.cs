using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_Shot : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.velocity = 20 * transform.forward;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = rb.velocity;

        // Destroy the shell after 5 seconds
        Destroy(this.gameObject, 5);
    }
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        rb.velocity = Vector3.Reflect(velocity, contact.normal);

    }

    
    
}
