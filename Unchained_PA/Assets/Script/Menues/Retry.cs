using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void RetryLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameObject.FindGameObjectWithTag("Player").GetComponent<damage>().hp = 100;
    }
}
