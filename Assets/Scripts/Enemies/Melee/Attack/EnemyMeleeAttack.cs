using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles melee attacks for enemy.
public class EnemyMeleeAttack : MonoBehaviour
{
    // Perform melee attack on target.
    public void Attack(GameObject target)
    {
        Health health = target.GetComponentInChildren<Health>();

        if (health != null)
        {
            health.ReduceLife(10);
        }
        else
        {
            Debug.LogError("El objetivo no tiene una vida");
        }
    }

    private void Start()
    {

    }
}