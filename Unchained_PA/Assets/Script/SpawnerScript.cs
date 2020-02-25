using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private float spawnDelay;

    private float lastSpawnDate;
    private RushToTarget _rushToTarget;
    private Text CounterOfKill;
    private string TextCountOfKill;

    void Start()
    {
        _rushToTarget = enemy.GetComponent<RushToTarget>();
        lastSpawnDate = Time.time;
        CounterOfKill = GameObject.FindGameObjectWithTag("CounterKill").GetComponent<Text>();
        
    }

    void Update()
    {
        TextCountOfKill = CounterOfKill.text;
        if (!TextCountOfKill.Equals("0") ) 
        {
            if (Time.time - lastSpawnDate >= spawnDelay)
            {
                var spawned = Instantiate(enemy, transform.position, Quaternion.identity);
                _rushToTarget.target = playerTransform;
                lastSpawnDate = Time.time;
            }
        }
        
        
        
    }
}
