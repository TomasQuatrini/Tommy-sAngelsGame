using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Health : MonoBehaviour, IHealth
{
    // Maximum life of the character
    [SerializeField] private float _maxHealth;

    // Current life of the character
    [SerializeField] private float _currentHealth;

    [SerializeField] private bool _hit = false;
    private float _HfillAmount;

    // Properties that allow access to life data
    public float MaxHealth { get { return _maxHealth; } }
    public float CurrentHealth { get { return _currentHealth; } }

    private void Start()
    {
        Initializing();
    }

    private void Update()
    {
        _HfillAmount = _currentHealth / _maxHealth;
    }

    // Method that reduces the character's life
    public void ReduceLife(float amount)
    {
        _currentHealth = _currentHealth - amount;
        Debug.Log("Health decrease: " + amount);
        if (_currentHealth < 0f)
        {
            _currentHealth = 0f;
        }
        _hit = true;
    }

    // Method that increases the character's life
    public void IncreaseLife(float amount)
    {
        _currentHealth = _currentHealth + amount;
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
        return _hit;
    }

    public void ResetHit()
    {
        _hit = false;
    }

    public float GetFillAmount()
    {
        return _HfillAmount;
    }
    public void Initialize(float maxHealth, float currentHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = currentHealth;
    }
}