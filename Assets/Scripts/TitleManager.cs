using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleManager : MonoBehaviour
{
    private string languageFile;
    public LocalizationManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Application.systemLanguage == SystemLanguage.English)
        {
            Debug.Log("English");
            languageFile = "lang_en.json";
        }
        else if (Application.systemLanguage == SystemLanguage.Finnish)
        {
            Debug.Log("Finnish");
            languageFile = "lang_fi.json";
        }
        else if (Application.systemLanguage == SystemLanguage.Portuguese)
        {
            Debug.Log("Portuguese");
            languageFile = "lang_pt.json";
        }
        else if (Application.systemLanguage == SystemLanguage.German)
        {
            Debug.Log("German");
            languageFile = "lang_de.json";
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            Debug.Log("Japanese");
            languageFile = "lang_ja.json";
        }
        else if (Application.systemLanguage == SystemLanguage.Russian)
        {
            Debug.Log("Russian");
            languageFile = "lang_ru.json";
        }
        else
        {
            Debug.Log("Unsupported language");
            languageFile = "lang_en.json";
        }
    }

    void Update()
    {
        if (Input.anyKey)
        {
            manager.LoadLocalizedText(languageFile);
        }
    }
}
