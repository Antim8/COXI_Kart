using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{

    public string firstLevel, secondLevel;
    
   public void LoadCoxiMap()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void LoadBasicMap()
    {
        SceneManager.LoadScene(secondLevel);
    }

    public void HeadBack()
    {
        this.gameObject.SetActive(false);
    }
}
