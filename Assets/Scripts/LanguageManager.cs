using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager instance;
    
    private Dictionary<string, string> translatedText;

    private bool isReady = false;
    private string missingTextString = "404";
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy (gameObject);
        }
        DontDestroyOnLoad (gameObject);
    }

    public void LoadTranslatedText(string fileName)
    {
        translatedText = new Dictionary<string, string> ();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText (filePath);
            LanguageData loadedData = JsonUtility.FromJson<LanguageData> (dataAsJson);
            for (int i = 0; i < loadedData.items.Length; i++)
            {
                translatedText.Add(loadedData.items [i].key, loadedData.items [i].value);
            }
            Debug.Log("Data loaded, dictionary contains: " + translatedText.Count + " entries");
        }
        else
        {
            Debug.LogError("Cannot find file");
        }
        isReady = true;
    }
    public string GetLanguageValue(string key)
    {
        string result = missingTextString;
        Debug.LogError("1");
        if (translatedText.ContainsKey(key))
        {
            result = translatedText[key];
        }
        Debug.LogError("2");
        return result;
    }
    public bool GetIsReady()
    {
        return isReady;
    }
}
