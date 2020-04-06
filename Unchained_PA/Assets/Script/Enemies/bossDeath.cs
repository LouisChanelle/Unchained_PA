using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossDeath : MonoBehaviour
{
    private List<GameObject> bossList = new List<GameObject>();
    private bool bossIsIn = false;
    private Canvas endCan;
    public int hp;
    
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
                Destroy(t);
            }

            if (bossIsIn)
            {
                endCan.enabled = true;
                Time.timeScale = 0;
            }
        }
    }
}
