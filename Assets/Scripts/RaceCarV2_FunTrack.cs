using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceCarV2_FunTrack : MonoBehaviour
{
    public static RaceCarV2_FunTrack Instance { get; private set; }
    public Transform centerOfMass;
    public float motorTorque = 1500f;
    public float maxSteer = 20f;
    public bool Finished { get; private set; }
    private bool Checkpoint;

    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody _rb;
    private Wheel[] _wheels;
    private bool _allowed;

    // Start is called before the first frame update
    void Start()
    {
        Finished = false;
        Checkpoint = false;
        _allowed = false;
        Instance = this;
        _wheels = GetComponentsInChildren<Wheel>();
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = centerOfMass.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (_allowed == true) return;
        Steer = GameManager.Instance.InputController.SteerInput;
        Throttle = GameManager.Instance.InputController.ThrottleInput;

        foreach (var wheel in _wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boost")
        {
            _rb.AddForce(transform.forward * 1000f, ForceMode.Acceleration);
        }
        else if (other.name == "Checkpoint")
        {
            Checkpoint = true;
        }
        else if (Checkpoint && other.name == "GoalTrigger")
        {
            Finished = true;
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "World")
        {
            transform.position = new Vector3(193.0f,6.0f,85.0f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
        }
    }
}
