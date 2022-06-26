using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {


        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
        }
    }
}
