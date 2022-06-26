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
        GameObject car = GameObject.FindWithTag("Car");
        Vector3 carDirection = car.transform.position - transform.position;
        transform.LookAt(car.transform);
        if (Physics.Raycast(transform.position, carDirection, out hit, 10.0f))
        {
            if (frequency == 1.0f)
            {
                Instantiate(_shellPrefab, transform.position + transform.forward * 1.5f, transform.rotation);
        
            }
        }
        frequency -= 0.02f;
        if (frequency < 0.0f)
        {
            frequency = 1.0f;
        }
    
    }
}
