using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    public Animator animator = new Animator();
    public LayerMask enemyLayers;
    public float damage;

    private bool isCrouching;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        damage = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Press S");
            isCrouching = true;
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            Debug.Log("Release S");
            isCrouching = false;
        }

        // Update the Animator parameter to control the crouch animation
        animator.SetBool("isCrouching", isCrouching);
        
    }

    void Attack(){
        if(animator != null){
            animator.SetTrigger("Attack");
        }
    }

    void Defend(){
        if(animator != null){
            animator.SetBool("isCrouching", true);
        }
    }

   


}
