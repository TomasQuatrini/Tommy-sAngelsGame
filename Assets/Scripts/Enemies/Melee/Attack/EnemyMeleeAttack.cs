using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles melee attacks for enemy.
public class EnemyMeleeAttack : MonoBehaviour
{
    // Melee attack handler.
    private MeleeAttack _meleeAttack;

    // Player movement reference.
    public PlayerMovement playerMovement;

    // Perform melee attack on target.
    public void Attack(GameObject target)
    {
        // Push player and perform attack.
        playerMovement.PushPlayer();
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            _meleeAttack.Attack(gameObject, target, playerHealth.health, 10);
        }
        else
        {
            Debug.LogError("El objetivo no tiene un componente PlayerHealth");
        }
    }

    // Initialize components.
    private void Start()
    {
        // Initialize melee attack handler.
        _meleeAttack = new MeleeAttack();
    }
}