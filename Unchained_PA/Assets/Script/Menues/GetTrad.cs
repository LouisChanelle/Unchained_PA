using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTrad : MonoBehaviour
{
    public Text language;
    public Text fullscreen;
    public Text sound;
    public Text retrn;
    public Text play;
    public Text quit;
    public Text returnEsc;
    public Text mainEsc;
    public Text died;
    public Text tryA;
    public Text mainD;
    public Text lvl;
    public Text suiv;
    public Text mainF;
    
    public Dropdown drp;
    
    private void Start()
    {
        language.text = PlayerPrefs.GetString("lang");
        fullscreen.text = PlayerPrefs.GetString("full");
        sound.text = PlayerPrefs.GetString("sound");
        retrn.text = PlayerPrefs.GetString("return");
        play.text = PlayerPrefs.GetString("play");
        quit.text = PlayerPrefs.GetString("quit");
        returnEsc.text = PlayerPrefs.GetString("returnEsc");
        mainEsc.text = PlayerPrefs.GetString("mainEsc");
        died.text = PlayerPrefs.GetString("die");
        tryA.text = PlayerPrefs.GetString("try");
        mainD.text = PlayerPrefs.GetString("mainD");
        lvl.text = PlayerPrefs.GetString("lvl");
        suiv.text = PlayerPrefs.GetString("suiv");
        mainF.text = PlayerPrefs.GetString("mainF");

        drp.value = PlayerPrefs.GetInt("int");
    }
}
