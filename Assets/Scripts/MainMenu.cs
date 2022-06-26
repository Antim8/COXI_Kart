using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;

    public GameObject optionsScreen;
    public GameObject levelSelection;
    public bool OptionsScreenState {  get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        OptionsScreenState = false;
    }
    
    public void StartGame()
    {
        levelSelection.SetActive(true);
        
    }

    public void HandleOptions() {

        if (OptionsScreenState)
        {
            optionsScreen.SetActive(false);
            OptionsScreenState = false;
        }
        else
        {
            optionsScreen.SetActive(true);
            OptionsScreenState = true;
        }
        
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
