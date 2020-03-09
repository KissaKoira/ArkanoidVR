using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionsUI;
    public GameObject loseUI;
    public GameObject winUI;

    bool menuActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        pauseMenuUI.SetActive(false);
        optionsUI.SetActive(false);
        loseUI.SetActive(false);
        winUI.SetActive(false);
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

    // Method called when entering options
    public void OptionsOpen()
    {
        optionsUI.SetActive(true);
    }

    // Method called when exiting options
    public void OptionsClose()
    {
        optionsUI.SetActive(false);
    }

    // Method called when going to main menu
    public void MainMenu()
    {
        // Tähän main menu siirtymäriitti //
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
