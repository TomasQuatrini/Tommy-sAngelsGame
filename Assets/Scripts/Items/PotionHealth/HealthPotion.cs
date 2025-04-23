using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// HealthPotion.cs
// A specific item that restores health

using UnityEngine;

[CreateAssetMenu(fileName = "New HealthPotion", menuName = "Items/HealthPotion")]
public class HealthPotion : Item
{
    // Amount of health to restore
    public int healthAmount = 50;

    // Use the health potion
    public override void Use()
    {
        // Find the player's health script
        PlayerHealth playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            // Restore health to the player
            playerHealth.TakeHealth(healthAmount);
        }
        else
        {
            Debug.LogError("PlayerHealth script not found");
        }
    }
}