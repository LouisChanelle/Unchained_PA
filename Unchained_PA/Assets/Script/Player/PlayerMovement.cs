using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotSpeed;
    private Quaternion from = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion to = Quaternion.Euler(0f, 180f, 0f);
    private bool isOnGround;
    private bool bossIsDead;
    private float posY;

    private void Start()
    {
        isOnGround = false;
        bossIsDead = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        var moveIntent = Vector3.zero;

        if (bossIsDead == false)
        {
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
        }

        moveIntent = moveIntent.normalized;


        transform.position += Time.deltaTime * moveSpeed * moveIntent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("world"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("world"))
        {
            isOnGround = false;
        }
    }

    public bool isGrounding()
    {
        if (isOnGround == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void jumpingAnim()
    {
        posY = transform.position.y;
        posY += 1;
    }

    public void bossDie()
    {
        bossIsDead = true;
    }
}

