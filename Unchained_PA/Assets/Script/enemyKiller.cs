using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class enemyKiller : MonoBehaviour
{
    [SerializeField] private Transform enemyPos;
    
    private void OnTriggerEnter (Collider other)
    {
        if (!Input.GetKey(KeyCode.A))
        {
            return;
        }

        if (other.CompareTag("enemy"))
        {
            Debug.Log("I'm in ! I'M IN");
            Collider.Destroy(other.gameObject);
        }
    }
}
