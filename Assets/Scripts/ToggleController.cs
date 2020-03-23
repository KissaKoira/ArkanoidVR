using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleController : MonoBehaviour
{
    public bool isLeftHanded;

    public Image toggleBg;
    public RectTransform toggle;

    public GameObject handle;
    private RectTransform handleTransform;
    private float handleSize;
    private float onPosX;
    private float offPosX;
    public float handleOffset;

    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public Color textOnColor;
    public Color textOffColor;
    public Color highlightedColor;

    public float speed;
    static float t = 0.0f;
    private bool switching = false;


    void Awake()
    {
        handleTransform = handle.GetComponent<RectTransform>();
        RectTransform handleRect = handle.GetComponent<RectTransform>();
        handleSize = handleRect.sizeDelta.x;
        float toggleSizeX = toggle.sizeDelta.x;
        onPosX = (toggleSizeX / 2) - (handleSize/2) - handleOffset;
		offPosX = onPosX * -1;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(isLeftHanded)
        {
            leftText.color = textOnColor;
            rightText.color = textOffColor;
            handleTransform.localPosition = new Vector3(onPosX, 0f, 0f);
        }
        else
        {
            leftText.color = textOffColor;
            rightText.color = textOnColor;
            handleTransform.localPosition = new Vector3(offPosX, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(switching)
        {
            Toggle(isLeftHanded);
        }
    }

    public void Switching()
    {
        switching = true;
    }

    public void Toggle(bool toggleStatus)
    {
        if(toggleStatus)
        {
            leftText.color = SmoothColor(textOnColor, textOffColor);
            rightText.color = SmoothColor(textOffColor, textOnColor);
            handleTransform.localPosition = SmoothMove(handle, onPosX, offPosX);
        }
        else
        {
            leftText.color = SmoothColor(textOffColor, textOnColor);
            rightText.color = SmoothColor(textOnColor, textOffColor);
            handleTransform.localPosition = SmoothMove(handle, offPosX, onPosX);
        }
    }

    Color SmoothColor(Color startColor, Color endColor)
    {
        Color resultColor;
        resultColor = Color.Lerp(startColor, endColor, t += speed * Time.unscaledDeltaTime);
        return resultColor;
    }

    Vector3 SmoothMove(GameObject toggleHandle, float startPosX, float endPosX)
    {
        Vector3 position = new Vector3 (Mathf.Lerp(startPosX, endPosX, t += speed * Time.unscaledDeltaTime), 0f, 0f);
        StopSwtiching();
        return position;
    }

    void StopSwtiching()
    {
        if(t > 1.0f)
        {
            switching = false;

            t = 0.0f;
            switch(isLeftHanded)
            {
                case true:
                    isLeftHanded = false;
                    Debug.Log(isLeftHanded);
                    break;

                case false:
                    isLeftHanded = true;
                    Debug.Log(isLeftHanded);
                    break;
            }
        }
    }
}
