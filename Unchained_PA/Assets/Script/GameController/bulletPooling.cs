using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPooling : MonoBehaviour
{
    private List<GameObject> pooledObjects;

    public GameObject objectToPool;

    public int amountToPool;
    
    private bool shouldExpand;

    public static bulletPooling SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
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
}
