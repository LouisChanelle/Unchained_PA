using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private float spawnDelay;

    private float lastSpawnDate;
    private RushToTarget _rushToTarget;

    void Start()
    {
        _rushToTarget = enemy.GetComponent<RushToTarget>();
        lastSpawnDate = Time.time;
    }

    void Update()
    {
        if (Time.time - lastSpawnDate >= spawnDelay)
        {
            var spawned = Instantiate(enemy, transform.position, Quaternion.identity);
            _rushToTarget.target = playerTransform;
            lastSpawnDate = Time.time;
        }
    }
}
