using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Player health script that handles player health and damage
public class PlayerHealth : MonoBehaviour
{
    // Reference to the Health component
    private Health _health;
    public BoxCollider2D boxCollider2D;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;
    private HealthBar _healthBar;

    // Reference to the player movement script
    public PlayerMovement playerMovement;

    // Initialize health component and set initial health value
    private void Start()
    {
        _healthBar = GameObject.FindObjectOfType<HealthBar>();
        if (_healthBar == null)
        {
            Debug.LogError("HealthBar component not found");
        }
        _healthBar.InitializeHealthBar(_currentHealth);
        // Get the Health component attached to this game object
        _health = GetComponent<Health>();
        // Set the initial health value
        _health.Initialize(100, 100);
        // Log the initial health value
        Debug.Log($"Player health set to: {_health.CurrentHealth}");
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.ChangeCurrentHealth(_currentHealth);
        _healthBar.ChangeMaxHealth(_maxHealth);
        TakingDamage();
        GetHealthValue();
        // Check if the player's health has reached zero
        if (_health.CurrentHealth <= 0)
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
        _health.IncreaseLife(amount);
        // Check if the player's health has reached maximum
        if (_health.CurrentHealth == _health.MaxHealth)
        {
            // The player has healed to maximum
            Debug.Log("Player has healed to max");
        }
    }

    // Method to handle player damage
    private void TakingDamage()
    {
        if (_health != null && _healthBar != null)
        {
            // Check if the player has been hit
            if (_health.GetHitStatus())
            {
                // Push the player back
                playerMovement.PushPlayer();
                // Reset the hit status
                _health.ResetHit();
            }
        }
    }

    private void GetHealthValue()
    {
        _currentHealth = _health.CurrentHealth;
        _maxHealth = _health.MaxHealth;
    }
    
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Die()
    {
        _healthBar = null;
        RestartScene();
    }
}