using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _moveForce;

    private readonly float _moveAcceleration = 100;
    private readonly float _drag = 0.993f;
    private readonly float _maxSpeed = 50;
    private readonly float _steerAngle = 20;
    private readonly float _traction = .5f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Moving
        _moveForce += transform.forward * _moveAcceleration * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += _moveForce * Time.deltaTime;

        //Steering
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * _moveForce.magnitude * Time.deltaTime * _steerAngle);

        //Drag
        _moveForce *= _drag;
        _moveForce = Vector3.ClampMagnitude(_moveForce, _maxSpeed);

        // Debug rays to see in which direction the car is being pushed
        Debug.DrawRay(transform.position, _moveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        _moveForce = Vector3.Lerp(_moveForce.normalized, transform.forward, _traction * Time.deltaTime) * _moveForce.magnitude;

    }
}
