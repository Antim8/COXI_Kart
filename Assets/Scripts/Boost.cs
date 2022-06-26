using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{

    private bool up;
    private float y_pos;
    // Start is called before the first frame update
    void Start()
    {
        // get y position
        y_pos = transform.position.y;
        // set the initial movement up
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Set up true if below lower limit
        if (transform.position.y < (y_pos + 1.0f))
        {
            up = true;
        }
        // Set up false if above upper limit
        if (transform.position.y > (y_pos + 1.5f))
        {
            up = false;
        }
        
        // Move up and down
        if (up)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 0.5f);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * 0.5f);
        }
    }
}
