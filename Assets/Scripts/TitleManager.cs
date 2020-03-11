using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleManager : MonoBehaviour
{
    //public GameObject titleScreenUI;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Application.systemLanguage == SystemLanguage.English)
        {
            Debug.Log("English");
            //lang_en.json
        }
        else if (Application.systemLanguage == SystemLanguage.Finnish)
        {
            Debug.Log("Finnish");
            //lang_fi.json
        }
        else if (Application.systemLanguage == SystemLanguage.Portuguese)
        {
            Debug.Log("Portuguese");
            //lang_pt.json
        }
        else if (Application.systemLanguage == SystemLanguage.German)
        {
            Debug.Log("German");
            //lang_de.json
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            Debug.Log("Japanese");
            //lang_ja.json
        }
        else if (Application.systemLanguage == SystemLanguage.Russian)
        {
            Debug.Log("Russian");
            //lang_ru.json
        }
        else
        {
            Debug.Log("Language not supported");
            //lang_en.json
        }
    }

    // Method called when moving to Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
