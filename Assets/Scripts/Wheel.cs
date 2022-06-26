using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    // Each wheel has the possibility to steer, get power or ivertsteer
    public bool steer;
    public bool invertSteer;
    public bool power;

    public float SteerAngle {get; set;}
    public float Torque {get; set;}

    private WheelCollider wheelCollider;
    private Transform wheelTransform;


    // Start is called before the first frame update
    void Start()
    {
        wheelCollider = GetComponentInChildren<WheelCollider>();
        wheelTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    // Apply steer and torque where necessary
    void FixedUpdate()
    {
        if (steer) {
            wheelCollider.steerAngle = SteerAngle * (invertSteer ? -1 : 1);
        }

        if (power) {
            wheelCollider.motorTorque = Torque;
        }
    }
}
