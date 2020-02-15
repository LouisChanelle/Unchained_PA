using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class enemyKiller : MonoBehaviour
{
    private List<GameObject> nearEnemy = new List<GameObject>();
    private Collider _collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            nearEnemy.Add(other.gameObject);
            Debug.Log("i'm in bruh");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            nearEnemy.Remove(other.gameObject);
            Debug.Log("i'm out bruh");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            foreach (GameObject t in nearEnemy)
            {
                Destroy(t);
            }
        }
    }
}
