using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        GameObject car = GameObject.Find("Car");
        Vector3 carPosition = car.transform.position;

        // Set the position of the camera to the position of the car
        transform.position = new Vector3(carPosition.x, carPosition.y + 100, carPosition.z);

        // Set y rotation to y rotation of the car
        transform.rotation = Quaternion.Euler(90, car.transform.rotation.eulerAngles.y, 0);

    }
}
