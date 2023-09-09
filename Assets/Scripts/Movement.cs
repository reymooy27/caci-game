using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float moveSpeed = 5f; // Adjust the movement speed as needed
    private bool isJumping;
    public Rigidbody2D rb;
    private Animator animator;
    public float jumpForce = 10.0f;
    float moveHorizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate(){

        if(Input.GetKey(KeyCode.D)){
            rb.velocity = new Vector2(1f * moveSpeed, rb.velocity.y);
            animator.SetBool("isRunning", true);
        }

        if(Input.GetKey(KeyCode.A)){
            rb.velocity = new Vector2(-1f * moveSpeed, rb.velocity.y);
            animator.SetBool("isRunning", true);
        }

        if(moveHorizontal == 0){
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && !isJumping) // Replace "Jump" with your jump input axis/button
        {
            // Apply an upward force to jump
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
        }else{
            animator.SetBool("isJumping", false);

        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Ground"){
            isJumping = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Ground"){
            isJumping = true;
        }
    }
}

