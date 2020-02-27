using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossDeath : MonoBehaviour
{
    private List<GameObject> bossList = new List<GameObject>();
    private bool bossIsIn = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("boss"))
        {
            bossIsIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("boss"))
        {
            bossIsIn = false;
        }
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            foreach (var t in bossList)
            {
                Destroy(t);
            }

            if (bossIsIn == true)
            {
                Debug.Log("bossIsIn");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}
