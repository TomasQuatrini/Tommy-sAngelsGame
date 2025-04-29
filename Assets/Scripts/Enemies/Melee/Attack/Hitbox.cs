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

                // Apply knockback to player.
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    // Calculate knockback direction.
                    Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;

                    // Apply knockback force.
                    playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                Debug.LogError("Enemy attack script no está asignado");
            }
        }
        else if (collision.gameObject.CompareTag("Enemies"))
        {
            return;
        }
    }
}