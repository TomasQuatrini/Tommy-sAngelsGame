using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Health : MonoBehaviour, IHealth
{
    // Maximum life of the character
    [SerializeField] private int _maxHealth = 100;

    // Current life of the character
    [SerializeField] private int _currentHealth = 100;

    [SerializeField] private bool hit = false;

    // Properties that allow access to life data
    public int MaxHealth { get { return _maxHealth; } }
    public int CurrentHealth { get { return _currentHealth; } }

    private void Start()
    {
        Initializing();
    }

    // Method that reduces the character's life
    public void ReduceLife(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Health decrease: " + amount);
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        hit = true;
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

    public void Initializing()
    {
        _currentHealth = _maxHealth;
    }

    public bool GetHitStatus()
    {
        return hit;
    }

    public void ResetHit()
    {
        hit = false;
    }

    public void Initialize(int maxHealth, int currentHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = currentHealth;
    }
}