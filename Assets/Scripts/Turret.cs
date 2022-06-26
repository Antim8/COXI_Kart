using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float frequency = 1.0f;
    [SerializeField]
    private GameObject _shellPrefab;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Get the GameObject car
        GameObject car = GameObject.FindWithTag("Car");
        // Get the direction to the car
        Vector3 carDirection = car.transform.position - transform.position;
        // Change the rotation of the current to always look at the car 
        transform.LookAt(car.transform);
        // Use raycasts to shoot a sheel when its 10.0f away
        if (Physics.Raycast(transform.position, carDirection, out hit, 10.0f))
        {
            // Always instantiate after a certain time
            if (frequency == 1.0f)
            {
                // Create the shell object and release it towards the car
                Instantiate(_shellPrefab, transform.position + transform.forward * 1.5f, transform.rotation);
        
            }
        }
        // Reduce the the frequency variable until zero and than set it to 1 again
        frequency -= 0.02f;
        if (frequency < 0.0f)
        {
            frequency = 1.0f;
        }
    
    }
}
