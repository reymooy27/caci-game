using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour

{
    public float maxHealth = 100f;
    private Animator animator;
    public GameObject hurtSoundObject;
    public AudioSource hurtSound;
    public GameObject bloodFx;
    private Animator anim;
    private Movement movement;
    private Combat combat;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hurtSoundObject = GameObject.Find("HurtSound");
        hurtSound = hurtSoundObject.GetComponent<AudioSource>();
        Animator anim = bloodFx.GetComponent<Animator>();
        movement = GetComponent<Movement>();
        combat = GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        maxHealth -= damage;
        animator.SetBool("hurt", true);
        bloodFx.SetActive(true);
        //anim.StartPlayback();
        hurtSound.Play();
        if (maxHealth <= 0)
        {
            animator.SetBool("hurt", false);
            animator.SetBool("isDeath", true);
            movement.enabled = false;
            combat.enabled = false;
            Die();
        }
    }

    private void Die()
    {
        // Implement any death logic here
        GameManager.Instance.GameOver(true);
        
        //Destroy(gameObject);
    }

    public void StopHurtAnimation()
    {
        animator.SetBool("hurt", false);
        bloodFx.SetActive(false);
        //anim.StopPlayback();
    }
}
