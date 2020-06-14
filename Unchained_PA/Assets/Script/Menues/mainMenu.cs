using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    private Canvas optionsCan;

    private void Awake()
    {
        optionsCan = GameObject.FindGameObjectWithTag("optionsCan").GetComponent<Canvas>();
        optionsCan.enabled = false;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Option()
    {
        optionsCan.enabled = true;
    }

    public void Back()
    {
        optionsCan.enabled = false;
    }
}
