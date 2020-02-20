using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("enemy")) return;
        hp -= 1;
        
        if (hp == 0)
        {
            Destroy(player);
        }

        Debug.Log(hp);
    }
}
