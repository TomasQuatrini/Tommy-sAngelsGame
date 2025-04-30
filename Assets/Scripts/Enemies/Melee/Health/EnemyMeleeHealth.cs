using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeHealth : MonoBehaviour
{
    // Reference to the enemy's health
    [SerializeField] Health health;
    [SerializeField] HealthBarEnemies healthBarEnemies;
    [SerializeField] float _currentHealth;
    [SerializeField] float _maxHealth;
    // Reference to the KeySpawner
    public KeySpawner keySpawner;

    private void Start()
    {
        // Get the Health component attached to this game object
        health = GetComponent<Health>();
        // Check if health is not null
        if (health != null)
        {
            // Initialize the enemy's health
            health.Initialize(100, 100); // Pasa los parámetros correspondientes
        }
        else
        {
            Debug.LogError("No Health component found");
        }
    }

    void Update()
    {
        // Check if the enemy is dead
        if (health.CurrentHealth <= 0)
        {
            Die();
        }
        CurrentHealth();
        SetHealthBar();
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

    public void CurrentHealth()
    {
        _currentHealth = health.CurrentHealth;
        _maxHealth = health.MaxHealth;
    }

    private void SetHealthBar()
    {
        healthBarEnemies.UpdateHealthbar(_maxHealth, _currentHealth);
    }
}