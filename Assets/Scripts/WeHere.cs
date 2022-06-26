using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeHere : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _up;
    private float _yPos;
    
    void Start()
    {
        _up = true;
        _yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Up and down Movement
        if (this.gameObject.activeSelf == true)
        {
            if (transform.position.y < (_yPos -20.0f))
            {
                _up = true;
            }
            if (transform.position.y > (_yPos + 5.5f))
            {
                _up = false;
            }

            if (_up)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 10.5f);
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime * 10.5f);
            }
        }
    }
}
