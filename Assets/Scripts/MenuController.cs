using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    // Does GameObject stuff
    public GameObject pauseMenuUI;
    public GameObject optionsUI;
    public GameObject loseUI;
    public GameObject winUI;

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
    void Paused()
    {
        Time.timeScale = 0f;

        pauseMenuUI.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
