using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Health : IHealth
{
    // Maximum life of the character
    [SerializeField] private int _maxHealth = 100;

    // Current life of the character
    [SerializeField] private int _currentHealth = 100;
    
    // Properties that allow access to life data
    public int MaxHealth { get { return _maxHealth; } }
    public int CurrentHealth { get { return _currentHealth; } }

    // Method that reduces the character's life
    public void ReduceLife(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Health decrease: " + amount);
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }

    // Method that increases the character's life
    public void IncreaseLife(int amount)
    {
        _currentHealth += amount;
        Debug.Log("Health increase: " + amount);
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    // Method that sets the character's health
    public void SetHealth(int maxHealth, int currentHealth)
    {
        this._maxHealth = maxHealth;
        this._currentHealth = currentHealth;
    }

    public void Initialize()
    {
        _currentHealth = _maxHealth;
    }
}