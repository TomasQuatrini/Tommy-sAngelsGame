using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeHealth : MonoBehaviour
{
    // Reference to the enemy's health
    public Health health;
    private int _currentHealth;
    // Reference to the KeySpawner
    public KeySpawner keySpawner;

    private void Start()
    {
        // Initialize the enemy's health
        health = new Health();
        health.SetHealth(100, 100);
        _currentHealth = health.CurrentHealth;
    }

    void Update()
    {
        // Update the current health
        _currentHealth = health.CurrentHealth;
        // Check if the enemy is dead
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Enemy death logic
        Debug.Log("Enemy killed");
        // Notify the KeySpawner that an enemy has been killed
        keySpawner.EnemyKilled();
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
}