using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Reference to the Life ScriptableObject
    public Health health;
    public BoxCollider2D boxCollider2D;

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
    void Update()
    {
        HandleInput();
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
            TakeHealth(20);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Se colisiono con los bordes");
        if (collision.gameObject.CompareTag("Edges"))
        {
            TakeDamage(30);
        }
    }
}
