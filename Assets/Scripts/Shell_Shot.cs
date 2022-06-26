using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_Shot : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _velocity;

    void Start()
    {
        // Get the rigidbody component and set the default velocity
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = 60 * transform.forward;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // update the current velocity value
        _velocity = _rb.velocity;

        // Destroy the shell after 5 seconds
        Destroy(this.gameObject, 5);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Reflect the movement's velocity at the point of contact 
        ContactPoint contact = collision.contacts[0];
        _rb.velocity = Vector3.Reflect(_velocity, contact.normal);
    }

    
    
}
