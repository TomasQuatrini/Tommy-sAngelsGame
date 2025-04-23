using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    // Reference to the health potion
    public HealthPotion healthPotion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.tag == "Player")
        {
            // Use the potion
            healthPotion.Use();
            // Destroy the potion GameObject
            Destroy(gameObject);
        }
    }
}