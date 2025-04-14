using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health", menuName = "Characters/Health")]
public class Health : ScriptableObject
{
    // Maximum life of the character
    [SerializeField] private int maxHealth = 100;

    // Current life of the character
    [SerializeField] private int currentHealth = 100;
    
    // Properties that allow access to life data
    public int MaxHealth { get { return maxHealth; } }
    public int CurrentHealth { get { return currentHealth; } }

    // Method that reduces the character's life
    public void ReduceLife(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Health decrease: " + amount);
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    // Method that increases the character's life
    public void IncreaseLife(int amount)
    {
        currentHealth += amount;
        Debug.Log("Health increase: " + amount);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // Method that sets the character's health
    public void SetHealth(int maxHealth, int currentHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
    }
}