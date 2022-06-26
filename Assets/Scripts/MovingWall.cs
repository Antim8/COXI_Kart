using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    private float _pos;
    private float _startPos; 
    private Vector3 _dir;
    private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        // get the inital x position if movement is in x-direction or y otherwise
        if (transform.eulerAngles.y == 0)
        {
            _startPos = transform.position.x;
        }
        else
        {
            _startPos = transform.position.z;
        }

        // set the default speed to 5 and inital direction to the right 
        _speed = 5.0f;
        _dir = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        // update the wall's position
        transform.Translate(_dir*_speed*Time.deltaTime);

        // get the current (important) wall position 
        if (transform.eulerAngles.y == 0)
        {
            _pos = transform.position.x;
        }
        else
        {
            _pos = transform.position.z;
        }

        // Move right, if at the left boundary 
        if (_pos < (_startPos - 7.0f))
        {
            _dir = Vector3.right;
            // In y-direction move in the left direction
            if (transform.eulerAngles.y == 90)
            {
                _dir = Vector3.left;
            }
            
        }
        // Move left, if the right boundary
        if (_pos > (_startPos + 7.0f))
        {
            _dir = Vector3.left;
             // In y-direction move in the right direction
            if (transform.eulerAngles.y == 90)
            {
                _dir = Vector3.right;
            }
        }        
    }
}
