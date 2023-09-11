using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class HitBox : MonoBehaviour

{
    private Animator animator;
    public GameObject parent;
    public GameObject hurtSoundObject;
    public AudioSource hurtSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = parent.GetComponent<Animator>();
        hurtSoundObject = GameObject.Find("HurtSound");
        hurtSound = hurtSoundObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other){
        // Check if the collided object has a Health script
        Health targetHealth = other.GetComponent<Health>();
        if (!GameManager.Instance.IsGameOver())
        {
            if (targetHealth != null)
            {
                // Deal damage to the target
                targetHealth.TakeDamage(10f);
                animator.SetBool("hurt", true);
                hurtSound.Play();
                Debug.Log("Take damage");
            }
        }

    }

    void OnTriggerExit2D(){
        animator.SetBool("hurt", false);
    }
}
