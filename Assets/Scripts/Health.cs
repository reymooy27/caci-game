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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hurtSoundObject = GameObject.Find("HurtSound");
        hurtSound = hurtSoundObject.GetComponent<AudioSource>();
        Animator anim = bloodFx.GetComponent<Animator>();
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
