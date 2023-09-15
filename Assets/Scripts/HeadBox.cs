using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBox : MonoBehaviour
{
    private Animator animator;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        animator = parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 9)
        {
            Health targetHealth = parent.GetComponent<Health>();
            if (!GameManager.Instance.IsGameOver())
            {
                if (targetHealth != null)
                {
                    // Deal damage to the target
                    Debug.Log(other);
                    targetHealth.TakeDamage(10f);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Health targetHealth = parent.GetComponent<Health>();
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
