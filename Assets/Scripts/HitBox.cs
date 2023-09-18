using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour

{
    private Animator animator;
    public GameObject parent;
    private Combat combat;
    // Start is called before the first frame update
    void Start()
    {
        animator = parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
        // Check if the collided object has a Health script
        if (!GameManager.Instance.IsGameOver())
        {
            Health targetHealth = other.GetComponent<Health>();
            combat = other.GetComponent<Combat>();
            if (targetHealth != null)
            {
                // Deal damage to the target
                Debug.Log(combat.isDefending);
                if (combat.isDefending)
                {
                    targetHealth.TakeDamage(1f);
                }
                else
                {
                    targetHealth.TakeDamage(5f);
                }
            }
        }

    }

    void OnTriggerExit2D(Collider2D other){
        Health targetHealth = other.GetComponent<Health>();
        if (!GameManager.Instance.IsGameOver())
        {
            if (targetHealth != null)
            {
                // Deal damage to the target
                targetHealth.StopHurtAnimation();
            }
        }
    }
}
