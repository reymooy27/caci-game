using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    public Animator animator = new Animator();
    public LayerMask enemyLayers;
    public float damage;

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
    }

    void Attack(){
        if(animator != null){
            animator.SetTrigger("Attack");
        }
    }

   


}
