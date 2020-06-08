using UnityEngine;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] private Transform playerTransform;

    private float spawnDelay = 0.5f;

    [SerializeField] private GameObject spawner;
    
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
        
        if (!TextCountOfKill.Equals("0"))
        {
            if (Time.time - lastSpawnDate >= spawnDelay)
            {
                GameObject enemies = objectPooling.SharedInstance.GetPooledObject();

                enemies.transform.position = spawner.transform.position;
                enemies.GetComponent<RushToTarget>().target = playerTransform;
                enemies.SetActive(true);
                lastSpawnDate = Time.time;
            }
        }
    }
}
