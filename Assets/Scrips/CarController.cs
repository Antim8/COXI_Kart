using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 MoveForce;

    private float MoveAcceleration = 100;
    private float Drag = 0.993f;
    private float MaxSpeed = 50;
    private float SteerAngle = 20;
    private float Traction = .5f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Moving
        MoveForce += transform.forward * MoveAcceleration * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        //Steering
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * Time.deltaTime * SteerAngle);

        //Drag
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;

    }
}
