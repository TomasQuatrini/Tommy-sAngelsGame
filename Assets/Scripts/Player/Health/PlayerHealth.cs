using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Player health script that handles player health and damage
public class PlayerHealth : MonoBehaviour
{
    // Reference to the Health component
    private Health health;
    public BoxCollider2D boxCollider2D;
    [SerializeField] float _currentHealth;
    [SerializeField] float _maxHealth;
    [SerializeField] private HealthBar healthBar;

    // Reference to the player movement script
    public PlayerMovement playerMovement;

    // Initialize health component and set initial health value
    private void Start()
    {
        healthBar.InitializeHealthBar(_currentHealth);
        // Get the Health component attached to this game object
        health = GetComponent<Health>();
        // Set the initial health value
        health.Initialize(100, 100);
        // Log the initial health value
        Debug.Log($"Player health set to: {health.CurrentHealth}");
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.ChangeCurrentHealth(_currentHealth);
        healthBar.ChangeMaxHealth(_maxHealth);
        TakingDamage();
        GetHealthValue();
        // Check if the player's health has reached zero
        if (health.CurrentHealth <= 0)
        {
            // The player has died
            Debug.Log("Player died");
            Die();
        }
    }

    // Method to heal the player
    public void TakeHealth(int amount)
    {
        // Increase the player's health
        health.IncreaseLife(amount);
        // Check if the player's health has reached maximum
        if (health.CurrentHealth == health.MaxHealth)
        {
            // The player has healed to maximum
            Debug.Log("Player has healed to max");
        }
    }

    // Method to handle player damage
    private void TakingDamage()
    {
        // Check if the player has been hit
        if (health.GetHitStatus())
        {
            // Push the player back
            playerMovement.PushPlayer();
            // Reset the hit status
            health.ResetHit();
        }
    }

    private void GetHealthValue()
    {
        _currentHealth = health.CurrentHealth;
        _maxHealth = health.MaxHealth;
    }
    
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Die()
    {
        RestartScene();
    }
}