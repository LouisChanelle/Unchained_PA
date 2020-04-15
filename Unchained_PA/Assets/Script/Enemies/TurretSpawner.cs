using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class TurretSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] public float spawnDelay;

    [SerializeField] private GameObject spawner;
    
    private float lastSpawnDate;
    private Text CounterOfKill;
    private string TextCountOfKill;

    void Start()
    {
        lastSpawnDate = Time.time;
        CounterOfKill = GameObject.FindGameObjectWithTag("CounterKill").GetComponent<Text>();
    }

    void Update()
    {
        TextCountOfKill = CounterOfKill.text;
        
        if (!TextCountOfKill.Equals("0"))
        {
            if (Time.time - lastSpawnDate >= spawnDelay)
            {
                GameObject turret = objectPooling.SharedInstance.GetScndPooledObject();

                turret.transform.position = spawner.transform.position;
                turret.SetActive(true);
                lastSpawnDate = Time.time;
            }
        }
    }
}
