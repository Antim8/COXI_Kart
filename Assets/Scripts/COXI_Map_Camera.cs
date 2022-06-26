using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COXI_Map_Camera : MonoBehaviour
{
    public GameObject finishScreen;
    public GameObject controls;
    
    public Vector3[] positions;

    public Quaternion[] rotations;

    // To keep track of current map
    private int _indexState;
    // Start is called before the first frame update
    void Start()
    {
        finishScreen.SetActive(false);
        controls.SetActive(false);
        transform.position = positions[0];
        transform.rotation = rotations[0];
    }

    // Update is called once per frame
    void Update()
    {
        _indexState = RaceCarV2.Instance.Map;

        if (_indexState > 0)
            controls.SetActive(true);

        if (RaceCarV2.Instance.Finished)
        {
            controls.SetActive(false);
            finishScreen.SetActive(true);
        }

        // Lerp is to make the transitions smooth 
        transform.position = Vector3.Lerp(transform.position, positions[_indexState], 2.0f * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotations[_indexState], 2.0f * Time.deltaTime);
    }
}
