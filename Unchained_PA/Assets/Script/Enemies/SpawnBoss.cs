using UnityEngine;
using UnityEngine.UI;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] private GameObject boss;

    [SerializeField] private Transform playerTransform;

    private float lastSpawnDate;
    private RushToTarget rushToTarget;
    private enemyKiller cptKills;
    private Text CounterOfKill;
    private string TextCountOfKill;
    private bool alreadySpawned;

    void Start()
    {
        alreadySpawned = false;
        rushToTarget = boss.GetComponent<RushToTarget>();
        CounterOfKill = GameObject.FindGameObjectWithTag("CounterKill").GetComponent<Text>();
    }

    void Update()
    {
        TextCountOfKill = CounterOfKill.text;
        if (TextCountOfKill.Equals("0") && alreadySpawned == false)
        {
            {
                var spawned = Instantiate(boss, transform.position, Quaternion.identity);
                spawned.GetComponent<RushToTarget>().target = playerTransform;
                lastSpawnDate = Time.time;
                alreadySpawned = true;
            }
        }
    }
}
