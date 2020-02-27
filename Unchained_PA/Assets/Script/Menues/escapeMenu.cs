using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class escapeMenu : MonoBehaviour
{
    private Canvas escapeCan;
    
    private void Start()
    {
        escapeCan = GameObject.FindGameObjectWithTag("escapeCanvas").GetComponent<Canvas>();
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
}
