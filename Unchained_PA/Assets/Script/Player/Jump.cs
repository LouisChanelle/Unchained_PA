using System;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;
     
    private bool isGrounded;
    Rigidbody rb;
    private bool isOnWorld;
    
    void Start(){
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
     
    void OnCollisionStay()
    {
        if(!isGrounded && isOnWorld) { 
            isGrounded = true; 
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag($"world"))
        {
            isOnWorld = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag($"world"))
        {
            isGrounded = false;
        }
    }

    void Update(){
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
     
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            isOnWorld = false;
        }
        
    }
}