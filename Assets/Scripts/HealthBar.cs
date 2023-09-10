using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider healthBar;
    public GameObject player;
    private Health playerHealth;

    void Start()
    {
        healthBar = GetComponent<Slider>();
        playerHealth = player.GetComponent<Health>();
        healthBar.maxValue = playerHealth.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerHealth.maxHealth;
    }
}
