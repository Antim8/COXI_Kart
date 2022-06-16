using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{

    private bool up;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(20, 0, 20);
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 1.0f)
        {
            up = true;
        }
        if (transform.position.y > 1.5f)
        {
            up = false;
        }

        if (up)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 0.5f);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * 0.5f);
        }
    }
}
