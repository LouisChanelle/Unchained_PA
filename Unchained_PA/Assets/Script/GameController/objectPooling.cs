using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class objectPooling : MonoBehaviour
{
    private List<GameObject> pooledObjects;

    private List<GameObject> scndPool;

    public GameObject objectToPool;

    public GameObject scndObjectToPool;

    public int amountToPool;

    public int amountToPoolScnd;

    private bool shouldExpand;

    public static objectPooling SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        scndPool = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

        for (int i = 0; i < amountToPoolScnd; i++)
        {
            GameObject obj = Instantiate(scndObjectToPool);
            obj.SetActive(false);
            scndPool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        
        return null;
    }

    public GameObject GetScndPooledObject()
    {
        for (int i = 0; i < scndPool.Count; i++)
        {
            if (!scndPool[i].activeInHierarchy)
            {
                return scndPool[i];
            }
        }

        return null;
    }
}
