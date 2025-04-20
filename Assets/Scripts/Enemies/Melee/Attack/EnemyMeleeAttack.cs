using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles melee attacks for enemy.
public class EnemyMeleeAttack : MonoBehaviour
{
    // Hitbox reference.
    public GameObject hitbox;

    // Movement references.
    private EnemyMeleeHorizontalMovement horizontalMovement;
    private EnemyMeleeVerticalMovement verticalMovement;

    // Melee attack handler.
    private MeleeAttack meleeAttack;

    // Direction flags.
    private bool lookRight = true;
    private bool lookUp = true;

    // Initialization flag.
    private bool initialized = false;

    // Player movement reference.
    public PlayerMovement playerMovement;

    // Perform melee attack on target.
    public void Attack(GameObject target)
    {
        // Push player and perform attack.
        playerMovement.PushPlayer();
        meleeAttack.Attack(gameObject, target, target.GetComponent<PlayerHealth>().health, 10);
    }

    // Initialize components.
    private void Start()
    {
        // Initialize melee attack handler.
        meleeAttack = new MeleeAttack();

        // Get movement components.
        horizontalMovement = GetComponent<EnemyMeleeHorizontalMovement>();
        verticalMovement = GetComponent<EnemyMeleeVerticalMovement>();
    }
}