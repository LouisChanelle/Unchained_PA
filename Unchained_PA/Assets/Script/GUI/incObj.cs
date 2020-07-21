using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incObj : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(objectPooling.SharedInstance.amountToPool);
        objectPooling.SharedInstance.amountToPool += 200;
    }
}
