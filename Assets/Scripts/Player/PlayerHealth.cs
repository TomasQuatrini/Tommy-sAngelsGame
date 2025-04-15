using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Reference to the Life ScriptableObject
    public Health health;

    private void Start()
    {
        if (!health)
        {
            Debug.LogError("SystemHealth asset not assigned in the inspector.");
            return;
        }
        health.SetHealth(100, 100);
        Debug.Log("Player health set to: " + health.CurrentHealth);
    }

    // Method that reduces the player's life
    public void TakeDamage(int amount)
    {
        health.ReduceLife(amount);
        if (health.CurrentHealth <= 0)
        {
            // The player has died
            Debug.Log("Player died");
        }
    }

    public void TakeHealth(int amount)
    {
        health.IncreaseLife(amount);
        {
            // The player has healed to max
            Debug.Log("Player has healed to max");
        }

    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(30);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            TakeHealth(20);
        }
    }

    void Update()
    {
        HandleInput();
    }
}
