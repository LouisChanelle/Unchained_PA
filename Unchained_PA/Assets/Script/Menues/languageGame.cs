using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class languageGame : MonoBehaviour
{
    public Text language;
    public Text fullscreen;
    public Text sound;
    public Text retrn;
    public Text returnEsc;
    public Text mainEsc;
    public Text died;
    public Text tryA;
    public Text mainD;
    public Text lvl;
    public Text suiv;
    public Text mainF;
    
    public Dropdown drp;

    private string strLanguage;
    private string strFullscreen;
    private string strSound;
    private string strReturn;
    private string strReturnEsc;
    private string strMainEsc;
    private string strDied;
    private string strTry;
    private string strMainD;
    private string strlvl;
    private string strsuiv;
    private string strMainF;

    public void SwitchLang()
    {
        Debug.Log("drp");
        if (drp.value == 0)
        {
            Debug.Log("English");
            strLanguage = "Language";
            strFullscreen = "Fullscreen";
            strSound = "Sound";
            strReturn = "Return";
            strReturnEsc = "Return";
            strMainEsc = "Main Menu";
            strDied = "YOU DIED !";
            strTry = "Try again";
            strMainD = "Main Menu";
            strlvl = "Level Completed !";
            strsuiv = "Next level";
            strMainF = "Main Menu";

            PlayerPrefs.SetInt("int", 0);
        }
        else if (drp.value == 1)
        {
            Debug.Log("French");
            strLanguage = "Langage";
            strFullscreen = "Plein écran";
            strSound = "Son";
            strReturn = "Retour";
            strReturnEsc = "Retour";
            strMainEsc = "Menu principal";
            strDied = "Vous êtes mort !";
            strTry = "Réessayer";
            strMainD = "Menu Principal";
            strlvl = "Niveau terminé";
            strsuiv = "Niveau suivant";
            strMainF = "Menu Principal";

            PlayerPrefs.SetInt("int", 1);
        }
        
        PlayerPrefs.SetString("lang", strLanguage);
        PlayerPrefs.SetString("full", strFullscreen);
        PlayerPrefs.SetString("sound", strSound);
        PlayerPrefs.SetString("return", strReturn);
        PlayerPrefs.SetString("returnEsc", strReturnEsc);
        PlayerPrefs.SetString("mainEsc", strMainEsc);
        PlayerPrefs.SetString("died", strDied);
        PlayerPrefs.SetString("try", strTry);
        PlayerPrefs.SetString("mainD", strMainD);
        PlayerPrefs.SetString("lvl", strlvl);
        PlayerPrefs.SetString("suiv", strsuiv);
        PlayerPrefs.SetString("mainF", strMainF);

        /*language.text = strLanguage;
        fullscreen.text = strFullscreen;
        sound.text = strSound;
        retrn.text = strReturn;
        returnEsc.text = strReturnEsc;
        mainEsc.text = strMainEsc;*/
        
        language.text = PlayerPrefs.GetString("lang");
        fullscreen.text = PlayerPrefs.GetString("full");
        sound.text = PlayerPrefs.GetString("sound");
        retrn.text = PlayerPrefs.GetString("return");
        returnEsc.text = PlayerPrefs.GetString("returnEsc");
        mainEsc.text = PlayerPrefs.GetString("mainEsc");
        died.text = PlayerPrefs.GetString("died");
        tryA.text = PlayerPrefs.GetString("try");
        mainD.text = PlayerPrefs.GetString("mainD");
        lvl.text = PlayerPrefs.GetString("lvl");
        suiv.text = PlayerPrefs.GetString("suiv");
        mainF.text = PlayerPrefs.GetString("mainF");
    }
}
