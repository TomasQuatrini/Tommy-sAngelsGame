using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player health script that handles player health and damage
public class PlayerHealth : MonoBehaviour
{
    // Reference to the Health component
    private Health health;
    public BoxCollider2D boxCollider2D;

    // Reference to the player movement script
    public PlayerMovement playerMovement;

    // Initialize health component and set initial health value
    private void Start()
    {
        // Get the Health component attached to this game object
        health = GetComponent<Health>();
        // Set the initial health value
        health.Initialize(100, 100);
        // Log the initial health value
        Debug.Log("Player health set to: " + health.CurrentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        TakingDamage();
        // Check if the player's health has reached zero
        if (health.CurrentHealth <= 0)
        {
            // The player has died
            Debug.Log("Player died");
            // Add logic to handle player death here
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
}