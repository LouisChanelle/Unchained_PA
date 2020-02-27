using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private GameObject ground;
    
    [SerializeField] private float jumpStartSpeed;
    private bool isJumping;
    private float currentSpeed;
    private float gravityMagnitude = -9.81f;

    private void Start()
    {
        Debug.Log(ground.transform.localScale.y);
    }

    void Update()
    {
        UpdateJumpPosition();
        CheckForJumpIntent();
    }

    private void UpdateJumpPosition()
    {
        if (!isJumping)
        {
            return;
        }

        currentSpeed += gravityMagnitude * Time.deltaTime;

        targetTransform.position += Time.deltaTime * currentSpeed * Vector3.up;

        if (!(targetTransform.position.y <= 3f))
        {
            return;
        }

        targetTransform.position = new Vector3(transform.position.x, 3f, transform.position.z);
        isJumping = false;
    }

    private void CheckForJumpIntent()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || isJumping)
        {
            return;
        }

        isJumping = true;
        currentSpeed = jumpStartSpeed;
    }
}
