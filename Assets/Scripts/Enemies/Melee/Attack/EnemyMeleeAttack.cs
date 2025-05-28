using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    // Reference hitbox
    public Hitbox hitbox;

    // Cooldown between attacks
    public float cooldown = 2f;

    // Indicates if the enemy can attack
    public bool canAttack = true;

    public void Attack(GameObject target)
    {
        Health health = target.GetComponentInChildren<Health>();

        if (health != null)
        {
            health.ReduceLife(10);
        }
        else
        {
            Debug.LogError("Target does not have a health component");
        }
    }

    public void ResetAttack()
    {
        // Enables attack capability after cooldown
        canAttack = true;
        // Deactivate collider hitbox
        hitbox.GetComponent<Collider2D>().enabled = false;
    }
}