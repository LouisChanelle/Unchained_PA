using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotSpeed;
    private Quaternion from = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion to = Quaternion.Euler(0f, 180f, 0f);
    private void Start()
    {
        
    }

    void Update()
    {
        var moveIntent = Vector3.zero;
        
        if (Input.GetKey(KeyCode.D))
        {
            moveIntent += Vector3.forward;
            transform.rotation = Quaternion.Lerp(to, from, Time.time * rotSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            moveIntent += Vector3.back;
            transform.rotation = Quaternion.Lerp(from, to, Time.time * rotSpeed);
        }
        
        
        moveIntent = moveIntent.normalized;
        

        transform.position += Time.deltaTime * moveSpeed * moveIntent;
    }
}
