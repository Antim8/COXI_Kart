using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COXI_Map_Camera : MonoBehaviour
{
    public GameObject finishScreen;
    public GameObject controls;
    
    public Vector3[] positions;

    public Quaternion[] rotations;

    private int index_state;
    // Start is called before the first frame update
    void Start()
    {
        finishScreen.SetActive(false);
        controls.SetActive(false);
//        index_state = RaceCarV2.Instance.Map;
        transform.position = positions[0];
        transform.rotation = rotations[0];
    }

    // Update is called once per frame
    void Update()
    {
        index_state = RaceCarV2.Instance.Map;

        if (index_state > 0)
            controls.SetActive(true);

        if (RaceCarV2.Instance.Finished)
        {
            controls.SetActive(false);
            finishScreen.SetActive(true);
        }
            //transform.position = positions[index_state];
        //transform.rotation = rotations[index_state];
        transform.position = Vector3.Lerp(transform.position, positions[index_state], 2.0f * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotations[index_state], 2.0f * Time.deltaTime);
    }
}
