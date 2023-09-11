using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float moveSpeed = 5f; // Adjust the movement speed as needed
    private bool isJumping;
    public Rigidbody2D rb;
    private Animator animator;
    public float jumpForce = 200f;
    float moveHorizontal;
    float moveVertical;

    public GameObject player1;
    public GameObject player2;

    public int playerNumber;
    private string horizontalAxis;
    private string verticalAxis;

    private GameObject jumpSoundObject;
    private AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        horizontalAxis = "Player" + playerNumber + "_Horizontal";
        verticalAxis = "Player" + playerNumber + "_Vertical";
        jumpSoundObject = GameObject.Find("JumpSound");
        jumpSound = jumpSoundObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis(horizontalAxis);
        moveVertical = Input.GetAxis(verticalAxis);

        if (player2 != null)
        {
            if (player1.transform.position.x > player2.transform.position.x)
            {
                player1.transform.localScale = new Vector3(-3.45f, 3.45f, 3.45f);
                player2.transform.localScale = new Vector3(3.45f, 3.45f, 3.45f);
            }else{
                player1.transform.localScale = new Vector3(3.45f, 3.45f, 3.45f);
                player2.transform.localScale = new Vector3(-3.45f, 3.45f, 3.45f);
            }
        }

    }

    void FixedUpdate(){
        if (!GameManager.Instance.IsGameOver())
        {
            if (moveHorizontal > 0f){
                rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
                animator.SetBool("isRunning", true);
            }

            if(moveHorizontal < 0f){
                rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
                animator.SetBool("isRunning", true);
            }

            if(moveHorizontal == 0){
                animator.SetBool("isRunning", false);
            }

            if (moveVertical > 0.1f && !isJumping)
            {
        
                rb.velocity = Vector2.up * jumpForce;
                animator.SetBool("isJumping", true);
                jumpSound.Play();
            }else{
                animator.SetBool("isJumping", false);

            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Ground"){
            isJumping = false;
            Debug.Log("Ground");
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Ground"){
            isJumping = true;
            Debug.Log("Air");
        }
    }
}

