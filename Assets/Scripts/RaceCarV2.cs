using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Base for every car instance we are using; slightly changed in the specific scripts
public class RaceCarV2 : MonoBehaviour
{
    
    public static RaceCarV2 Instance { get; private set; }
    public Transform centerOfMass;
    public float motorTorque = 1500f;
    public float maxSteer = 20f;
    public bool Finished { get; private set; }

    private Vector3[] positions = new[]
    {
        new Vector3(103.5f, 30.0f, -1115.0f), new Vector3(31.0f, 30.0f, -608.0f), new Vector3(68.0f, 69.0f, -156f), new Vector3(65.0f, 34.0f, -213.5f),
        new Vector3(98.0f, 24.0f, 345.0f)
    };

    private Quaternion[] rotations = new[]
    {
        Quaternion.Euler(0.0f, 180.0f, 0.0f), Quaternion.Euler(0.0f, -90.0f, 0.0f), Quaternion.Euler(0.0f, 225.0f, 0.0f), Quaternion.Euler(0.0f, -45.0f, 0.0f),
        Quaternion.Euler(0.0f, -90.0f, 0.0f)
    };
    public int Map { get; private set; }

    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody _rb;
    private Wheel[] _wheels;
    private bool _allowed;
    public GameObject beacon;

    // Start is called before the first frame update
    void Start()
    {
        Finished = false;
        _allowed = false;
        Instance = this;
        Map = 0;
        _wheels = GetComponentsInChildren<Wheel>();
        _rb = GetComponent<Rigidbody>();
        
        // Change the center of mass so that the car doesn't roll over that much
        _rb.centerOfMass = centerOfMass.localPosition;
        
        // These Coroutines are to prevent from doing something while the game loads or shows around
        StartCoroutine(WaitForStart(3));
        StartCoroutine(WaitForCamera(1));


    }

    // Update is called once per frame
    void Update()
    {
        if (Map <= 0 && _allowed == true) return;
        Steer = GameManager.Instance.InputController.SteerInput;
        Throttle = GameManager.Instance.InputController.ThrottleInput;
        
        // Applying the force to every wheel that is eligible 
        foreach (var wheel in _wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }

    // Waiter Threads
    private IEnumerator WaitForStart(int secs)
    {
        yield return new WaitForSeconds(secs);
        _allowed = true;
        StartCoroutine(WeHereBeacon(3));
    }
    
    private IEnumerator WaitForCamera(int secs)
    {
        yield return new WaitForSeconds(secs);
        Map = 1;
    }

    // Thread to spawn Beacon over the car after every teleport
    private IEnumerator WeHereBeacon(int secs)
    {
        beacon.SetActive(true);
        yield return new WaitForSeconds(secs);
        beacon.SetActive(false);
        
    }

    // To reset position to last checkpoint; also used for teleporting
    public void ResetPosition()
    {
        if (Map == 0) return;
        transform.position = positions[Map - 1];
        transform.rotation = rotations[Map - 1];
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        
        // To see which teleporter has been activated
        switch (other.name)
        {
            case "TeleporterC":
                Map = 2;
                break;
            
            case "TeleporterO":
                Map = 3;
                break;
            
            case "TeleporterX_1":
                Map = 4;
                break;
            
            case "TeleporterX_2":
                Map = 5;
                break;
            
            case "Finish":
                Finished = true;
                Map = 0;
                break;
        }
        ResetPosition();
        StartCoroutine(WeHereBeacon(3));
        
    }
}
