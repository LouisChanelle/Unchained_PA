using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] private float waitTime = 2.0f;
    private float timer = 0.0f;
    private projectile _rushToTarget;
    public Transform playerTransform;
    private bool IsIn = false;

    private void Awake()
    {
        _rushToTarget = bullet.GetComponent<projectile>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                bullet = bulletPooling.SharedInstance.GetPooledObject();

                bullet.transform.position = gameObject.transform.position;
                _rushToTarget.target = playerTransform;
                bullet.SetActive(true);

                timer = timer - waitTime;
            }
        }
    }
}
