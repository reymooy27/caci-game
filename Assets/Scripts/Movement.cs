using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float moveSpeed = 5f; // Adjust the movement speed as needed
    // public float jumpForce = 10f;
    // private bool isGrounded = true;
    public Rigidbody2D rb;
    private Animator animator = new Animator();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

        if(Input.GetKey(KeyCode.Space)){
            animator.SetTrigger("Attack");
        }

    }
}

