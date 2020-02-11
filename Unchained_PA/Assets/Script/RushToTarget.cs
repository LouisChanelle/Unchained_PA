using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushToTarget : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private float moveSpeed;

    void Update()
    {
        if (target == null)
        {
            return;
        }

        transform.LookAt(target);

        var direction = target.position - transform.position;
        direction.y = 0;
        direction = direction.normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}