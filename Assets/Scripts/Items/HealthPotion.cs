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
    public int healthAmount;

    // Use the health potion
    public override void Use()
    {
        // Code to restore health
        Debug.Log("Health restored");
    }
}