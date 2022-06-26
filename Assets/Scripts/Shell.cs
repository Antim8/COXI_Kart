using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // By collision with the car object destroy
        if (collision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
        }
    }
}
