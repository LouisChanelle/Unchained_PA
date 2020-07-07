using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class resolution : MonoBehaviour
{
    private GameObject optionsObj;
    
    public void Resolution()
    {
        Dropdown dropdown = optionsObj.GetComponentInChildren<Dropdown>();
        
        if (dropdown.value == 0)
        {
            PlayerPrefs.SetInt("width", 1920);
            PlayerPrefs.SetInt("height", 1080);
        }
        else if (dropdown.value == 1)
        {
            PlayerPrefs.SetInt("width", 1080);
            PlayerPrefs.SetInt("height", 720);
        }
        else if (dropdown.value == 2)
        {
            PlayerPrefs.SetInt("width", 800);
            PlayerPrefs.SetInt("height", 600);
        }
        dropdown.Hide();
    }
}