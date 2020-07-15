using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class damage : MonoBehaviour
{
    public float hp;

    public Image Health;

    public bool GODMODE = false;

    public Canvas DeathScreen;
    
    private void Start()
    {
        hp = 1.0f;

        DeathScreen.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!GODMODE)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                if (other.gameObject.CompareTag($"boss"))
                {
                    hp -= 0.03f;
                    Health.fillAmount = hp;
                }

                if (hp <= 0)
                {
                    Destroy(gameObject);

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

                    Time.timeScale = 0;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GODMODE)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                if (other.gameObject.CompareTag($"enemy"))
                {
                    hp -= 0.02f;
                    Health.fillAmount = hp;
                }

                if (other.gameObject.CompareTag($"bullet"))
                {
                    hp -= 0.02f;
                    Health.fillAmount = hp;
                }

                if (hp <= 0)
                {
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

                    DeathScreen.enabled = true;
                    
                    Time.timeScale = 0;
                }
            }
        }
    }

    private void Update()
    {
        if (gameObject.transform.position.y < -150f)
        {
            DeathScreen.enabled = true;
                    
            Time.timeScale = 0;
        }
    }
}
