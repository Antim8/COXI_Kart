using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {


        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            Destroy(gameObject);
        }
    }
}
