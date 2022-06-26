using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    private bool move_right;
    private float pos;
    private float start_pos; 
    private Vector3 dir;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.eulerAngles.y == 0)
        {
            start_pos = transform.position.x;
        }
        else
        {
            start_pos = transform.position.z;
        }

        speed = 5.0f;
        move_right = true;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(dir*speed*Time.deltaTime);

        if (transform.eulerAngles.y == 0)
        {
            pos = transform.position.x;
        }
        else
        {
            pos = transform.position.z;
        }

        if (pos < (start_pos - 7.0f))
        {
            move_right = true;
            if (transform.eulerAngles.y == 90)
            {
                move_right = false;
            }
            
        }
        if (pos > (start_pos + 7.0f))
        {
            move_right = false;
            if (transform.eulerAngles.y == 90)
            {
                move_right = true;
            }
        }

        if (move_right)
        {
            dir = Vector3.right;
        }
        else
        {
           dir = Vector3.left;
        }
        
    }
}
