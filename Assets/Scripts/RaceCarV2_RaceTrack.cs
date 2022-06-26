using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class RaceCarV2_RaceTrack : MonoBehaviour
{
    public static RaceCarV2_RaceTrack Instance { get; private set; }
    public Transform centerOfMass;
    public float motorTorque = 1500f;
    public float maxSteer = 20f;
    private bool _allowed;
    private bool _started;
    private Vector3 _lastCheckPosition;
    private Quaternion _lastCheckRotation;
    private bool _checkpointReached;
    public bool Finished { get; private set; }
    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody _rb;
    private Wheel[] _wheels;
    public TMP_Text timer;

    private float _startTime;
    private float _elapsedTime;
    public GameObject uiControl;
    public GameObject uiFinish;
    

    // Start is called before the first frame update
    void Start()
    {
        _lastCheckPosition = transform.position;
        _lastCheckRotation = transform.rotation;
        Finished = false;
        _started = false;
        _checkpointReached = false;
        uiControl.SetActive(true);
        Instance = this;
        _allowed = false;
        _wheels = GetComponentsInChildren<Wheel>();
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = centerOfMass.localPosition;
        StartCoroutine(WaitForCamera(1));


    }

    // Update is called once per frame
    void Update()
    {
        if (_allowed != true) return;
        Steer = GameManager.Instance.InputController.SteerInput;
        Throttle = GameManager.Instance.InputController.ThrottleInput;

        foreach (var wheel in _wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }

        if (_started)
        {
            _elapsedTime = Time.time - _startTime;
            timer.text = "Lap Time: " + _elapsedTime;
        }
    }
    private IEnumerator WaitForCamera(int secs)
    {
        yield return new WaitForSeconds(secs);
        _allowed = true;
    }

    public void ResetPosition()
    {
        transform.position = _lastCheckPosition;
        transform.rotation = _lastCheckRotation;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "FinishTrigger":
                if (_started)
                {
                    if(!_checkpointReached)
                        return;
                    Finished = true;
                    _rb.isKinematic = true;
                    _started = false;
                    uiFinish.SetActive(true);
                    _allowed = false;
                    uiControl.SetActive(false);
                    timer.text = "Lap Time: " + _elapsedTime;
                    
                }
                else
                {
                    _started = true;
                    _startTime = Time.time;
                }
                break;
            case  "CheckpointTrigger":
                if (_started && ! _checkpointReached)
                {
                    _checkpointReached = true;
                    _lastCheckPosition = transform.position;
                    _lastCheckRotation = transform.rotation;

                }
                else if (!_started)
                {
                    ResetPosition();
                }
                break;

        }
    }
}
