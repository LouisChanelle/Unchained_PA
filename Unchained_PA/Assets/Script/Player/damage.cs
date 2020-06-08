using UnityEngine;
using UnityEngine.SceneManagement;

public class damage : MonoBehaviour
{
    public int hp;
    private void Start()
    {
        hp = 1000;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (other.gameObject.tag.Equals("boss"))
            {
                hp -= 3;
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

    private void Update()
    {
        if (gameObject.transform.position.y < -250f)
        {
            Destroy(gameObject);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
