using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    public Animator animator = new Animator();
    public float maxHealth = 100;
    public float damage = 10;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            Attack();
        }
    }

    void Attack(){
        if(animator != null){
            animator.SetTrigger("Attack");
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (((1 << other.gameObject.layer) & enemyLayers) != 0)
        {
            // Check if the collided object has a Health script
            Combat targetHealth = other.gameObject.GetComponent<Combat>();

            if (targetHealth != null)
            {
                // Deal damage to the target
                targetHealth.TakeDamage(damage);
                Debug.Log("Take damage");
            }

        }
    }

    public void TakeDamage(float damage)
    {
        maxHealth -= damage;
        if (maxHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implement any death logic here
        Destroy(gameObject);
    }


}
