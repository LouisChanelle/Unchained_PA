using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    private float waitTime = 2.0f;
    private float timer = 0.0f;
    private RushToTarget _rushToTarget;
    public Transform playerTransform;
    private RushToTarget _rushToTarget1;

    private void Awake()
    {
        _rushToTarget1 = bullet.GetComponent<RushToTarget>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("In");
        
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            bullet = bulletPooling.SharedInstance.GetPooledObject();

            bullet.transform.position = gameObject.transform.position;
            _rushToTarget1.target = playerTransform;
            bullet.SetActive(true);
            
            timer = timer - waitTime;
        }
    }
}
