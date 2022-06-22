using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCar : MonoBehaviour
{

    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    public Transform wheelFLTrans;
    public Transform wheelFRTrans;
    public Transform wheelRLTrans;
    public Transform wheelRRTrans;

    public float motorTorque = 100f;
    public float maxSteer = 20f;
    public Transform centerOfMass;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.localPosition;
    }

    void FixedUpdate() {
        wheelRL.motorTorque = motorTorque * Input.GetAxis("Vertical");
        wheelRR.motorTorque = motorTorque * Input.GetAxis("Vertical");
        wheelFL.steerAngle = maxSteer * Input.GetAxis("Horizontal");
        wheelFR.steerAngle = maxSteer * Input.GetAxis("Horizontal");
    }

    

    // Update is called once per frame
    void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        wheelFL.GetWorldPose(out pos, out rot);
        wheelFLTrans.position = pos;
        wheelFLTrans.rotation = rot;

        wheelFR.GetWorldPose(out pos, out rot);
        wheelFRTrans.position = pos;
        wheelFRTrans.rotation = rot * Quaternion.Euler(0, 180, 0);

        wheelRL.GetWorldPose(out pos, out rot);
        wheelRLTrans.position = pos;
        wheelRLTrans.rotation = rot;

        wheelRR.GetWorldPose(out pos, out rot);
        wheelRRTrans.position = pos;
        wheelRRTrans.rotation = rot * Quaternion.Euler(0, 180, 0);

 

        
    }
}
