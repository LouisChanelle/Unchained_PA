using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class languages : MonoBehaviour
{
    public Text language;
    public Text fullscreen;
    public Text sound;
    public Text retrn;
    public Text play;
    public Text quit;
    public Dropdown drp;
    
    private string strLanguage;
    private string strFullscreen;
    private string strSound;
    private string strReturn;
    private string strPlay;
    private string strQuit;

    public void SwitchLang()
    {
        Debug.Log("drp");
        if (drp.value == 0)
        {
            strLanguage = "Language";
            strFullscreen = "Fullscreen";
            strSound = "Sound";
            strReturn = "Return";
            strPlay = "Play";
            strQuit = "Quit";

            PlayerPrefs.SetInt("int", 0);
        }
        else if (drp.value == 1)
        {
            strLanguage = "Langage";
            strFullscreen = "Plein écran";
            strSound = "Son";
            strReturn = "Retour";
            strPlay = "Jouer";
            strQuit = "Quitter";

            PlayerPrefs.SetInt("int", 1);
        }
        
        
        PlayerPrefs.SetString("lang", strLanguage);
        PlayerPrefs.SetString("full", strFullscreen);
        PlayerPrefs.SetString("sound", strSound);
        PlayerPrefs.SetString("return", strReturn);
        PlayerPrefs.SetString("play", strPlay);
        PlayerPrefs.SetString("quit", strQuit);

        language.text = PlayerPrefs.GetString("lang");
        fullscreen.text = PlayerPrefs.GetString("full");
        sound.text = PlayerPrefs.GetString("sound");
        retrn.text = PlayerPrefs.GetString("return");
        play.text = PlayerPrefs.GetString("play");
        quit.text = PlayerPrefs.GetString("quit");
    }
}
