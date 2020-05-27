﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Placed on "bullet" gameobject to make it target the player*/

public class projectile : MonoBehaviour
{
    /*public Transform target;
    public float moveSpeed;
    private GameObject _gameObject;
    private Transform _transform;

    private void Start()
    {
        _gameObject = GameObject.FindGameObjectWithTag("Player");
        _transform = _gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        target = _transform;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject o;
            (o = gameObject).SetActive(false);
            o.transform.position = _transform.position;
        }
    }*/
    
    public Transform target;
    public float moveSpeed;
    private GameObject _gameObject;
    private Transform _transform;

    private void Start()
    {
        _gameObject = GameObject.FindGameObjectWithTag("Player");
        _transform = _gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        target = _transform;
        if (target == null)
        {
            return;
        }
        
        var direction = target.position - transform.position;
        direction.x = 0;
        direction = direction.normalized;
    
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject o;
            (o = gameObject).SetActive(false);
            o.transform.position = _transform.position;
        }
    }
}