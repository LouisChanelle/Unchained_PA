using System.Collections.Generic;
using UnityEngine;

public class worldGeneration : MonoBehaviour
{
    public List<GameObject> prefabList = new List<GameObject>();
    private List<GameObject> popedPrefab = new List<GameObject>();

    public GameObject Prefab1;

    public GameObject Prefab2;

    public GameObject Prefab3;
    private Vector3 _base = Vector3.zero;
    [SerializeField] private int ite;
    private Vector3 pos;

    private GameObject SelectPrefab()
    {
        prefabList.Add(Prefab1);
        prefabList.Add(Prefab2);
        prefabList.Add(Prefab3);
        
        int prefabIndex = UnityEngine.Random.Range(0, 3);

        return prefabList[prefabIndex];
    }

    private void Awake()
    {
        
        for (int i = 0; i < ite; i++)
        {
            GameObject prefab = SelectPrefab();
            
            
            if (i == 0)
            {
                Instantiate(prefab, Vector3.zero, Quaternion.identity);
            }
            
            else
            {
                if (popedPrefab[i-1] == Prefab1)
                {
                    pos += new Vector3(0, popedPrefab[i - 1].transform.position.y,
                               popedPrefab[i - 1].transform.position.z)
                           + new Vector3(0, UnityEngine.Random.Range(-10, 2), 110);

                    Instantiate(prefab, pos, Quaternion.identity);
                }

                else if (popedPrefab[i-1] == Prefab2)
                {
                    pos += new Vector3(0, popedPrefab[i - 1].transform.position.y,
                               popedPrefab[i - 1].transform.position.z)
                           + new Vector3(0, UnityEngine.Random.Range(-10, 2), 80);

                    Instantiate(prefab, pos, Quaternion.identity);
                }
                else if (popedPrefab[i-1] == Prefab3)
                {
                    pos += new Vector3(0, popedPrefab[i - 1].transform.position.y,
                               popedPrefab[i - 1].transform.position.z)
                           + new Vector3(0, UnityEngine.Random.Range(-10, 2), 70);

                    Instantiate(prefab, pos, Quaternion.identity);
                }
            }
            popedPrefab.Add(prefab);
        }
    }
}
