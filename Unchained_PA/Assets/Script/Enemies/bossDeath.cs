using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bossDeath : MonoBehaviour
{
    private List<GameObject> bossList = new List<GameObject>();
    private bool bossIsIn = false;
    private Canvas endCan;
    private float hp = 100f;
    private Score score;
    public static Text setScore;
  

    private void Start()
    {
        endCan = GameObject.FindGameObjectWithTag("EndCanvas").GetComponent<Canvas>();
        endCan.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("boss"))
        {
            bossList.Add(other.gameObject);
            bossIsIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("boss"))
        {
            bossList.Remove(other.gameObject);
            bossIsIn = false;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
        {
            foreach (var t in bossList)
            {
                hp -= 0.5f;
            }

            
        }

        if (hp <= 0)
        {
            foreach (var t in bossList)
            {
                Destroy(t);
                
                if (bossIsIn)
                {
                    GetComponent<Ending>().End();
                    score.SetScore(Convert.ToInt32(setScore));
                    DontDestroyOnLoad(setScore);
                }
            }
        }
    }
}
