using UnityEngine;

public class Boost : MonoBehaviour
{

    private bool _up;
    private float _yPos;
    // Start is called before the first frame update
    void Start()
    {
        // get y position
        _yPos = transform.position.y;
        // set the initial movement up
        _up = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Set up true if below lower limit
        if (transform.position.y < (_yPos + 1.0f))
        {
            _up = true;
        }
        // Set up false if above upper limit
        if (transform.position.y > (_yPos + 1.5f))
        {
            _up = false;
        }
        
        // Move up and down
        if (_up)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 0.5f);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * 0.5f);
        }
    }
}
