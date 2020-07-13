using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screen : MonoBehaviour
{
    private Toggle optionsObj;

    private void Start()
    {
        PlayerPrefs.SetInt("width", 1920);
        PlayerPrefs.SetInt("height", 1080);
    }

    public void Fullscreen()
    {
        int width = PlayerPrefs.GetInt("width");
        int height = PlayerPrefs.GetInt("height");
        
        optionsObj = GameObject.Find("CanvasOptions").GetComponentInChildren<Toggle>();

        if (optionsObj.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            //Screen.SetResolution(width, height, FullScreenMode.Windowed);
        }

    }
}
