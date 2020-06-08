using UnityEngine;

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
