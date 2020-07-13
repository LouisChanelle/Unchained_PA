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
    
    private void Start()
    {
        hp = 1.0f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!GODMODE)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                if (other.gameObject.tag.Equals($"boss"))
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
                    hp -= 0.1f;
                    Health.fillAmount = hp;
                }

                if (other.gameObject.CompareTag($"bullet"))
                {
                    hp -= 0.1f;
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

    private void Update()
    {
        Debug.Log(hp);
        if (gameObject.transform.position.y < -150f)
        {
            Destroy(gameObject);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
