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
        Debug.Log("Game is paused");

        pauseMenuUI.SetActive(true);
        menuActive = true;
    }

    // Method called when exiting pause menu
    public void PauseMenuClose()
    {
        Time.timeScale = 1f;
        Debug.Log("No longer paused");

        pauseMenuUI.SetActive(false);
        optionsUI.SetActive(false);
        menuActive = false;
    }

    // Method called when restarting level
    public void Restart()
    {
        SceneManager.LoadScene("stage1");
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
        SceneManager.LoadScene("Main Menu");
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
