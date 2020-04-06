using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class damage : MonoBehaviour
{
    [SerializeField] private int hp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("boss"))
        {
            hp -= 3;
        }
        else
        {
            hp--;
        }

        if (hp == 0)
        {
            Destroy(gameObject);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
