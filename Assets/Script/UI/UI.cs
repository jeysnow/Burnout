using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI : MonoBehaviour
{
    public TMP_Text Text;
    public static UI instance;
    public Image textBox;
    public GameObject cenaFinal;

    public Canvas canvas;


    public Image image;

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        
        canvas = GetComponentInChildren<Canvas>();
        Text = GetComponentInChildren<TMP_Text>();

    }

    public void ColorSwap(int colorNumber)
    {
        switch (colorNumber)
        {
            case 0:
                image.color = Color.yellow;
                break;
            case 1:
                image.color = Color.blue;
                break;
            case 2:
                image.color = Color.red;
                break;
            default:
                image.color = Color.white;
                break;
        }        
    }

    public void Win()
    {
        cenaFinal.SetActive(true);
    }


    public void ShowText(string text)
    {
        Debug.Log(text);
        if(text == "")
        {
            image.enabled = false;
        }
        else
        {
            image.enabled = true;
        }

        Text.enabled = true;
        Text.text = text;
    }

    public void HideText()
    {
        Text.enabled = false;
        image.enabled = false;
    }
}
