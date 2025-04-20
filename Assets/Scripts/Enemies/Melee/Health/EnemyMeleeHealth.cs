using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeHealth : MonoBehaviour
{
    public Health healthSO; // Asignar el scriptable object Health en el inspector
    private int currentHealth;

    private void Start()
    {
        currentHealth = healthSO.MaxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
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
}

