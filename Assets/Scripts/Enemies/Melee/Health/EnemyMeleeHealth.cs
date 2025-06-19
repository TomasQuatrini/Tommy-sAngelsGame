using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeHealth : MonoBehaviour
{
    // Reference to the enemy's health
    [SerializeField] Health health;
    private void Start()
    {
        // Get the Health component attached to this game object
        health = GetComponent<Health>();
        // Check if health is not null
        if (health != null)
        {
            // Initialize the enemy's health
            health.Initialize(40, 40); // Pass the corresponding parameters
        }
        else
        {
            Debug.LogError("No Health component found");
        }
    }

    void Update()
    {        
        CheckDead();        
    }

    private void Die()
    {
        // Destroy the enemy GameObject
        Destroy(gameObject);
    }

    // Reduce the enemy's life
    public void ReduceLife(int amount)
    {
        health.ReduceLife(amount);
    }

    // Get the enemy's health
    public IHealth GetHealth()
    {
        return health;
    }

    private void CheckDead()
    {
    // Check if the enemy is dead
        if (health.CurrentHealth <= 0)
        {
            Die();
        }
    }

    public bool IsAlive()
    {
        return health.CurrentHealth > 0;
    }
}
