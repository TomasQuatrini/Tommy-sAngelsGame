using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles hitbox logic for enemy attacks.
public class Hitbox : MonoBehaviour
{
    // Reference to enemy attack script.
    public EnemyMeleeAttack enemyAttack;

    // Knockback force applied to player.
    public float knockbackForce = 7f;

    // Draw gizmo for hitbox visualization.
    private void OnDrawGizmos()
    {
        // Set gizmo color to red.
        Gizmos.color = Color.red;

        // Draw wire cube representing hitbox.
        Gizmos.DrawWireCube(transform.position, new Vector3(1f, 1f, 1f));
    }

    // Handle collision with player.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collision is with player.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if enemy attack script is assigned.
            if (enemyAttack != null)
            {
                // Apply damage to player.
                enemyAttack.Attack(collision.gameObject);

                // Calculate knockback direction.
                Vector2 knockbackDirection = GetKnockbackDirection();

                // Apply knockback to player.
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    // Apply knockback force.
                    playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                Debug.LogError("Enemy attack script is not assigned");
            }
        }
        else if (collision.gameObject.CompareTag("Enemies"))
        {
            return;
        }
    }

    // Calculate knockback direction based on enemy movement.
    private Vector2 GetKnockbackDirection()
    {
        // Get the velocity of the enemy.
        Vector2 velocity = enemyAttack.GetComponent<EnemyMeleeMovement>().GetVelocity();

        // Calculate the direction of the knockback.
        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
        {
            return velocity.x > 0 ? new Vector2(1, 0) : new Vector2(-1, 0);
        }
        else
        {
            return velocity.y > 0 ? new Vector2(0, 1) : new Vector2(0, -1);
        }
    }
}