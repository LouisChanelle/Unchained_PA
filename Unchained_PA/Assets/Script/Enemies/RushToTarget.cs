﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushToTarget : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        transform.LookAt(target);

        var direction = target.position - transform.position;
        direction.x = 0;
        direction = direction.normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}