using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject levelSelectUI;
    public GameObject levelInfoUI;
    public GameObject optionsUI;
    public GameObject creditsUI;
    public GameObject exitUI;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        //mainMenuUI.SetActive(false);
        levelSelectUI.SetActive(false);
        levelInfoUI.SetActive(false);
        optionsUI.SetActive(false);
        creditsUI.SetActive(false);
        exitUI.SetActive(false);
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
        levelInfoUI.SetActive(false);
    }


    // Method called when selecting a level
    public void LevelInfo()
    {
        levelSelectUI.SetActive(false);
        levelInfoUI.SetActive(true);
    }


    // Method called when entering a game scene
    public void EnterLevel()
    {
        // koodii tähän
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
        // Enter game closing code here //
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
