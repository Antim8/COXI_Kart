using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{

    public string inputSteerAxis = "Horizontal";
    public string inputPowerAxis = "Vertical";

    public float ThrottleInput { get; private set; }
    public float SteerInput { get; private set; }


    // Start is called before the first frame update
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (RaceCarV2_RaceTrack.Instance != null) 
                RaceCarV2_RaceTrack.Instance.ResetPosition();
            else if (RaceCarV2.Instance != null)
                RaceCarV2.Instance.ResetPosition();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        SteerInput = Input.GetAxis(inputSteerAxis);
        ThrottleInput = Input.GetAxis(inputPowerAxis);
    }
}
