using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float moveSpeed = 5f; // Adjust the movement speed as needed
    // public float jumpForce = 10f;
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
        if(moveHorizontal != 0){
            rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
            animator.SetBool("isRunning", true);
        }else{
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && !isJumping) // Replace "Jump" with your jump input axis/button
        {
            // Apply an upward force to jump
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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

