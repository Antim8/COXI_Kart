using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    
    private float speed = 1.0f;
    private int itemNum = 0;
    private Rigidbody rb;
    [SerializeField]
    private GameObject _shellPrefab;
     
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        rb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement of the car
        MoveCar();

        SpeedDecrease();
        
        if (itemNum != 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (itemNum == 1)
                {
                    // get position in front of the car 
                    Vector3 position = transform.position + transform.forward * 1.5f;
                    Instantiate(_shellPrefab, position, this.transform.rotation);
                    itemNum = 0;
                }
                

            }
            
        }


    }
    void SpeedDecrease()
    {
        if (speed > 1.0f)
        {
            speed -= 0.01f;
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
        

        if (collision.gameObject.tag == "Shell")
        {
            // Delete game object
            itemNum = 1;
        }
        if (collision.gameObject.tag == "Shell_Shot")
        {
            //rb.isKinematic = true;
            // Destroy game object
            //Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            Destroy(collision.gameObject);
            rb.velocity = Vector3.zero;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boost")
        {
            // Speed up the car
            speed += 3f;
        }
    }
    
}
