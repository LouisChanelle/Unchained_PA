using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    void Update()
    {
        var moveIntent = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            moveIntent += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            moveIntent += Vector3.back;
        }

        moveIntent = moveIntent.normalized;

        transform.position += Time.deltaTime * moveSpeed * moveIntent;
    }
}
