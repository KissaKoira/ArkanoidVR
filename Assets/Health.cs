using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

public int maxHealth = 100;
public int currentHealth;
public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ball")

        {
            TakeDamage(25);
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void TakeDamage(int damage)   
{
    currentHealth -= damage;

    healthBar.SetHealth(currentHealth);
}
}
