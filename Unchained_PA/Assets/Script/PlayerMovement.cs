using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotSpeed;
    private void Start()
    {
        
    }

    void Update()
    {
        var moveIntent = Vector3.zero;
        float rotate = 0f;
        
        if (Input.GetKey(KeyCode.D))
        {
            moveIntent += Vector3.forward;
            rotate += 30f;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            moveIntent += Vector3.back;
            rotate += 30f;
        }
        
        
        moveIntent = moveIntent.normalized;
        

        transform.position += moveIntent * moveSpeed * Time.deltaTime;
    }
}
