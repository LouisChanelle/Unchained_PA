using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escapeMenu : MonoBehaviour
{
    private Canvas escapeCan;
    private Canvas optionsCan;
    public int scnIdx;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        escapeCan = GameObject.FindGameObjectWithTag("escapeCanvas").GetComponent<Canvas>();
        optionsCan = GameObject.FindGameObjectWithTag("optionsCan").GetComponent<Canvas>();
        optionsCan.enabled = false;
        escapeCan.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            escapeCan.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void ReturnGame()
    {
        escapeCan.enabled = false;
        Time.timeScale = 1;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void GoToOptions()
    {
        optionsCan.enabled = true;
    }

    public void GoToEscapeMenu()
    {
        escapeCan.enabled = true;
        optionsCan.enabled = false;
    }
}
