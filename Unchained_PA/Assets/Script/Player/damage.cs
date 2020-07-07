using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class damage : MonoBehaviour
{
    public int hp;

    public Image Health;
    public Image Energy;

    public bool GODMODE = false;
    
    private void Start()
    {
        hp = 100;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!GODMODE)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                if (other.gameObject.tag.Equals("boss"))
                {
                    hp -= 3;

                    Health.image.width = hp;
                    Debug.Log(hp);
                    Debug.Log(Health.image.width);
                }
                else if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("bullet"))
                {
                    hp--;
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
        if (gameObject.transform.position.y < -150f)
        {
            Destroy(gameObject);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        Health.image.width = hp;
        
        Debug.Log(hp);
        Debug.Log(Health.image.width);
    }
}
