using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Horizontal movement handler for melee enemy.
public class EnemyMeleeHorizontalMovement : EnemyMeleeMovement
{
    // Left and right patrol points.
    public float leftPatrolPoint = -5f;
    public float rightPatrolPoint = 5f;

    // Hitbox reference.
    public GameObject hitbox;

    // Patrol logic.
    protected override void Patrol()
    {
        // Move towards target based on current direction.
        if (isMovingTowardsTarget)
        {
            MoveTowardsTarget(new Vector2(rightPatrolPoint, transform.position.y));
        }
        else
        {
            MoveTowardsTarget(new Vector2(leftPatrolPoint, transform.position.y));
        }
    }

    // Target reached logic.
    protected override void OnTargetReached()
    {
        // Flip enemy's horizontal direction.
        FlipHorizontal();
    }

    // Get direction of enemy's movement.
    public Vector2 GetDirection()
    {
        // Return direction based on current movement.
        return isMovingTowardsTarget ? Vector2.right : Vector2.left;
    }

    // Flip enemy's horizontal direction.
    private void FlipHorizontal()
    {
        // Update enemy's horizontal scale.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Adjust hitbox position based on enemy's movement direction.
    private void AjustHitbox()
    {
        // Set hitbox position based on direction.
        hitbox.transform.localPosition = new Vector3(Mathf.Sign(GetDirection().x) * 0.5f, 0, 0);
    }
}
