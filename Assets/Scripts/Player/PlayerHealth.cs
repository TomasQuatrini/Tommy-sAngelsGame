using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Reference to the Health
    public Health health;
    public BoxCollider2D boxCollider2D;

    private void Start()
    {
        health = new Health();
        health.SetHealth(100, 100);
        Debug.Log("Player health set to: " + health.CurrentHealth);
    }

    void Update()
    {
        HandleInput();
        if (health.CurrentHealth <= 0)
        {
            // The player has died
            Debug.Log("Player died");
            // Puedes agregar lógica para manejar la muerte del jugador aquí
        }
    }

    public void TakeHealth(int amount)
    {
        health.IncreaseLife(amount);
        if (health.CurrentHealth == health.MaxHealth)
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
}