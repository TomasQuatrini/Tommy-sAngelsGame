using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeHealth : MonoBehaviour
{
    public Health health;
    private int _currentHealth;

    private void Start()
    {
        health = new Health();
        health.SetHealth(100, 100);
        _currentHealth = health.CurrentHealth;
    }

    void Update()
    {
        _currentHealth = health.CurrentHealth;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Lógica para matar al enemigo
        Debug.Log("Enemigo muerto");
        Destroy(gameObject);
    }

    public void ReduceLife(int amount)
    {
        health.ReduceLife(amount);
    }

    public IHealth GetHealth()
    {
        return health;
    }
}

