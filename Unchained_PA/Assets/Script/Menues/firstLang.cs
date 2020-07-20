using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstLang : MonoBehaviour
{
    private string strLanguage;
    private string strFullscreen;
    private string strSound;
    private string strReturn;
    private string strPlay;
    private string strQuit;

    private void Awake()
    {
        strLanguage = "Language";
        strFullscreen = "Fullscreen";
        strSound = "Sound";
        strReturn = "Return";
        strPlay = "Play";
        strQuit = "Quit";


        PlayerPrefs.SetString("lang", strLanguage);
        PlayerPrefs.SetString("full", strFullscreen);
        PlayerPrefs.SetString("sound", strSound);
        PlayerPrefs.SetString("return", strReturn);
        PlayerPrefs.SetString("play", strPlay);
        PlayerPrefs.SetString("quit", strQuit);
    }
}
