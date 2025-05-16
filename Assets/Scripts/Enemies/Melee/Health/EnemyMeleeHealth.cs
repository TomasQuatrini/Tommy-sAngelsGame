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
        CurrentHealth();
        SetHealthBar();
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

    public void CurrentHealth()
    {
        _currentHealth = health.CurrentHealth;
        _maxHealth = health.MaxHealth;
    }

    private void SetHealthBar()
    {
        healthBarEnemies.UpdateHealthbar(_maxHealth, _currentHealth);
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
