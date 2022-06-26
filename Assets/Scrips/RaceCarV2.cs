using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCarV2 : MonoBehaviour
{

    public Transform centerOfMass;
    public float motorTorque = 1500f;
    public float maxSteer = 20f;

    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody rb;
    private Wheel[] wheels;

    // Start is called before the first frame update
    void Start()
    {

        wheels = GetComponentsInChildren<Wheel>();
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        Steer = GameManager.Instance.InputController.SteerInput;
        Throttle = GameManager.Instance.InputController.ThrottleInput;

        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "TeleporterC")
        {
            transform.position = new Vector3(31.0f,30.0f,-608.0f);
            transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }
        else if (other.name == "TeleporterO")
        {
            transform.position = new Vector3(83.0f,67.0f,-154.5f);
            transform.rotation = Quaternion.Euler(0.0f, 45.0f, 0.0f);
        }
        else if (other.name == "TeleporterX_1")
        {
            transform.position = new Vector3(79.0f,33.0f,-213.5f);
            transform.rotation = Quaternion.Euler(0.0f, -45.0f, 0.0f);
        }
        else if (other.name == "TeleporterX_2")
        {
            transform.position = new Vector3(100.5f,23.5f,344.5f);
            transform.rotation = Quaternion.Euler(0.0f, -45.0f, 0.0f);
        }

    }
}
