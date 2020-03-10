using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizedText : MonoBehaviour
{
    public string key;
    
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        Debug.Log(text);
        text.text = LocalizationManager.instance.GetLocalizedValue(key);
    }
}
