using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    private float pos;
    private float start_pos; 
    private Vector3 dir;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        // get the inital x position if movement is in x-direction or y otherwise
        if (transform.eulerAngles.y == 0)
        {
            start_pos = transform.position.x;
        }
        else
        {
            start_pos = transform.position.z;
        }

        // set the default speed to 5 and inital direction to the right 
        speed = 5.0f;
        dir = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        // update the wall's position
        transform.Translate(dir*speed*Time.deltaTime);

        // get the current (important) wall position 
        if (transform.eulerAngles.y == 0)
        {
            pos = transform.position.x;
        }
        else
        {
            pos = transform.position.z;
        }

        // Move right, if at the left boundary 
        if (pos < (start_pos - 7.0f))
        {
            dir = Vector3.right;
            // In y-direction move in the left direction
            if (transform.eulerAngles.y == 90)
            {
                dir = Vector3.left;
            }
            
        }
        // Move left, if the right boundary
        if (pos > (start_pos + 7.0f))
        {
            dir = Vector3.left;
             // In y-direction move in the right direction
            if (transform.eulerAngles.y == 90)
            {
                dir = Vector3.right;
            }
        }        
    }
}
