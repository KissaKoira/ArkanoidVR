using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    // GameObject stuff
    public GameObject mainMenuUI;
    public GameObject levelSelectUI;
    public GameObject optionsUI;
    public GameObject creditsUI;
    public GameObject exitUI;
    
    public GameObject pauseMenuUI;
    public GameObject loseUI;
    public GameObject winUI;

    bool menuActive = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        //mainMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        levelSelectUI.SetActive(false);
        optionsUI.SetActive(false);
        creditsUI.SetActive(false);
        exitUI.SetActive(false);
        loseUI.SetActive(false);
        winUI.SetActive(false);
    }

    // Method called when entering main menu
    public void MainMenu()
    {
        mainMenuUI.SetActive(true);

        optionsUI.SetActive(false);
        creditsUI.SetActive(false);
        levelSelectUI.SetActive(false);
        exitUI.SetActive(false);
    }


    // Method called when entering level select
    public void LevelSelect()
    {
        levelSelectUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }


    // Method called when entering options
    public void OptionsOpen()
    {
        optionsUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    // Method called when exiting options
    public void OptionsClose()
    {
        optionsUI.SetActive(false);
    }


    // Method called when opening credits
    public void Credits()
    {
        creditsUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }


    // Method called when selecting exit
    public void Exit()
    {
        exitUI.SetActive(true);
    }

    // Method called when closing the game
    public void TerminateGame()
    {
        // Enter game closing code here
    }


    // Method called when game is paused
    public void PauseMenuOpen()
    {
        Time.timeScale = 0f;

        pauseMenuUI.SetActive(true);
        menuActive = true;
        Debug.Log("auki");
    }

    // Method called when exiting pause menu
    public void PauseMenuClose()
    {
        Time.timeScale = 1f;

        pauseMenuUI.SetActive(false);
        //optionsUI.SetActive(false);
        menuActive = false;
        Debug.Log("sulki");
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(menuActive == false)
            {
                PauseMenuOpen();
            }
            else
            {
                PauseMenuClose();
            }
        }
    }
}
