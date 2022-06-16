using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Collider m_ObjectCollider;
    private float speed = 1.0f;
    private int itemNum = 0;
    private Rigidbody rb;
    [SerializeField]
    private GameObject _shellPrefab;
     
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        m_ObjectCollider = GetComponent<Collider>();
        m_ObjectCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement of the car
        MoveCar();

        SpeedDecrease();
        //m_ObjectCollider.isTrigger = true;

        if (itemNum != 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (itemNum == 1)
                {
                    Instantiate(_shellPrefab, transform.position, this.transform.rotation);
                    itemNum = 0;
                }
                

            }
            
        }


    }
    void SpeedDecrease()
    {
        if (speed > 1.0f)
        {
            speed -= 0.05f;
        }
    }

    void MoveCar()
    {
        // Control the car 
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5f * speed);
            RotateCar();
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 3f * speed);
            RotateCar();
        }
    }

    void RotateCar()
    {
        if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.down * Time.deltaTime * 100);
            }
        if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * Time.deltaTime * 100);
            }
    }

    void OnCollisionEnter(Collision collision)
    {
    
    
        
    }   
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Boost")
        {
            // Speed up the car
            speed += 3f;
        }

        if (other.tag == "Shell")
        {
            // Delete game object
            itemNum = 1;
        }
    }
}
