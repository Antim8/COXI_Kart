using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public string inputSteerAxis = "Horizontal";
    public string inputPowerAxis = "Vertical";

    public float ThrottleInput { get; private set; }
    public float SteerInput { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SteerInput = Input.GetAxis(inputSteerAxis);
        ThrottleInput = Input.GetAxis(inputPowerAxis);
    }
}
