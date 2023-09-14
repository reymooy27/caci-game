using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    public Animator animator = new Animator();
    public LayerMask enemyLayers;
    public float damage;
    private GameObject attackSoundObject;
    private AudioSource attackSound;
    private Movement movement;
    private bool isCrouching;
    private string attackButton;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        damage = 10f;
        attackSoundObject = GameObject.Find("AttackSound");
        attackSound = attackSoundObject.GetComponent<AudioSource>();
        attackButton = "Player" + movement.playerNumber + "_Attack";
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!movement.isJumping && Input.GetButton(attackButton)){
            Attack();
        }
        if (movement.isJumping && Input.GetButton(attackButton))
        {
            animator.SetBool("isJumpAttack",true);
        }
        if (!movement.isJumping)
        {
            animator.SetBool("isJumpAttack", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Press S");
            isCrouching = true;
            movement.enabled = false;
            
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            Debug.Log("Release S");
            isCrouching = false;
            movement.enabled = true;
        }

        // Update the Animator parameter to control the crouch animation
        animator.SetBool("isCrouching", isCrouching);
        
    }

    void Attack(){
        if(animator != null){
            animator.SetTrigger("Attack");
            attackSound.Play();
        }
    }

    void Defend(){
        if(animator != null){
            animator.SetBool("isCrouching", true);
        }
    }

   


}
