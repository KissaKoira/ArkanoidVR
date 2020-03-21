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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")

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
