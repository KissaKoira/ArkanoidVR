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
        HealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ball")

        {
            TakeDamage(25);
        }
    }

    void TakeDamage(int damage)   
{
    currentHealth -= damage;

    HealthBar.SetHealth(currentHealth);
}
}
