using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random = System.Random;

public class worldGeneration : MonoBehaviour
{
    public List<GameObject> prefabList = new List<GameObject>();
    private List<GameObject> popedPrefab = new List<GameObject>();

    public GameObject Prefab1;

    public GameObject Prefab2;

    public GameObject Prefab3;
    private Vector3 _base = Vector3.zero;

    private GameObject SelectPrefab()
    {
        int col = UnityEngine.Random.Range(0, 3);
        
        prefabList.Add(Prefab1);
        prefabList.Add(Prefab2);
        prefabList.Add(Prefab3);
        

        int prefabIndex = UnityEngine.Random.Range(0, 3);

        
        return prefabList[prefabIndex];
    }

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {

            GameObject prefab = SelectPrefab();

            
            if (i == 0)
            {
                Instantiate(prefab, Vector3.zero, Quaternion.identity);
            }
            else
            {
                var pos = new Vector3(0, popedPrefab[i-1].transform.position.y,
                              popedPrefab[i-1].transform.localScale.z) 
                          + new Vector3(0, UnityEngine.Random.Range(-10, 10),60*i);

                Instantiate(prefab, pos, Quaternion.identity);
            }
            popedPrefab.Add(prefab);
        }
    }
}
