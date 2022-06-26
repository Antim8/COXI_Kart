using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            transform.position = new Vector3(80.0f, 16.0f, -100.0f);
            transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            transform.position = new Vector3(100.0f, 16.0f, -100.0f);
            transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            transform.position = new Vector3(190.0f, 16.0f, 0.0f);
            transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            transform.position = new Vector3(120.0f, 16.0f, -120.0f);
            transform.rotation = Quaternion.Euler(0.0f, -45.0f, 0.0f);
        }
        
        rb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement of the car
        MoveCar();

        // Decrease the boost after awhile
        SpeedDecrease();
        
        // Pick the Shell up and release it by pressing the space bar
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
        // Reduce the speed boost each iteration
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
            transform.Translate(Vector3.forward * Time.deltaTime * 20f * speed);
            RotateCar(1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 3f * speed);
            RotateCar(-1);
        }
    }

    void RotateCar(int direction)
    {
        // Set the rotation of the car when steering the car
        if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.down * Time.deltaTime * 100 * direction);
            }
        if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * Time.deltaTime * 100 * direction);
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
            // Destroy the shell projectile and set the car's velocity to zero
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
        else if(other.tag == "Teleporter")
        {
            // Change the current scene to the next 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        else if(other.tag == "JumpPack")
        {
            // Jump the car
            rb.AddForce(Vector3.up * 20f, ForceMode.Impulse);
        }
        else if(other.tag == "JumpPackHigh")
        {
            // Jump the car
            rb.AddForce(Vector3.up * 40f, ForceMode.Impulse);
        }
    }
    
}
