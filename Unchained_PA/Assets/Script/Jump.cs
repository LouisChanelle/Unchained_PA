using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    
    [SerializeField] private float jumpStartSpeed;
    private bool isJumping;
    private float currentSpeed;
    [SerializeField] private float gravityMagnitude;
    
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

        if (!(targetTransform.position.y <= 0f))
        {
            return;
        }

        targetTransform.position = Vector3.zero;
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
