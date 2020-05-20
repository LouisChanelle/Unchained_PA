using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class TurretSpawner : MonoBehaviour
{
    public GameObject enemy;

    [SerializeField] private float spawnDelay;

    public GameObject spawner;
    

    void Start()
    {
        Instantiate(enemy, spawner.transform);
    }
}
