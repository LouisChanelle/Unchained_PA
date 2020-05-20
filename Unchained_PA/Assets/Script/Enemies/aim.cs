using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
    private GameObject _target;
    
    void Update()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(_target.transform);
    }
}
