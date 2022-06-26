using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // "Singleton like" structure to prevent from getting to many Managers
    public static GameManager Instance { get; private set; }
    public InputController InputController { get; private set; }

    void Awake()
    {
        Instance = this;
        InputController = GetComponentInChildren<InputController>();
    }
    
}
