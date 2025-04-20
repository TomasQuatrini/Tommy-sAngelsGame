using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract base class for enemy melee movement.
public abstract class EnemyMeleeMovement : MonoBehaviour
{
    // Movement speed.
    public float speed = 4f;

    // Target position.
    protected Vector2 targetPosition;

    // Flag to determine movement direction.
    protected bool isMovingTowardsTarget = true;

    // Update movement.
    protected virtual void Update()
    {
        // Patrol between targets.
        Patrol();
    }

    // Abstract method for patrolling.
    protected abstract void Patrol();

    // Move towards target position.
    protected void MoveTowardsTarget(Vector2 target)
    {
        // Update position.
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Check if target is reached.
        if (Vector2.Distance(transform.position, target) < 0.01f)
        {
            // Flip movement direction.
            isMovingTowardsTarget = !isMovingTowardsTarget;

            // Call target reached logic.
            OnTargetReached();
        }
    }

    // Get movement direction.
    public Vector2 GetDirection()
    {
        // Determine direction based on movement type.
        if (this is EnemyMeleeHorizontalMovement)
        {
            return isMovingTowardsTarget ? Vector2.right : Vector2.left;
        }
        else if (this is EnemyMeleeVerticalMovement)
        {
            return isMovingTowardsTarget ? Vector2.up : Vector2.down;
        }
        return Vector2.zero;
    }

    // Abstract method for target reached logic.
    protected abstract void OnTargetReached();
}