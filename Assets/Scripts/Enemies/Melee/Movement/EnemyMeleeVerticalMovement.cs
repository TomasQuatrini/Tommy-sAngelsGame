using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Vertical movement handler for melee enemy.
public class EnemyMeleeVerticalMovement : EnemyMeleeMovement
{
    // Top and bottom patrol points.
    public float topPatrolPoint = 5f;
    public float bottomPatrolPoint = -5f;

    // Hitbox reference.
    public GameObject hitbox;

    // Patrol logic.
    protected override void Patrol()
    {
        // Move towards target based on current direction.
        if (isMovingTowardsTarget)
        {
            MoveTowardsTarget(new Vector2(transform.position.x, topPatrolPoint));
        }
        else
        {
            MoveTowardsTarget(new Vector2(transform.position.x, bottomPatrolPoint));
        }
    }

    // Target reached logic.
    protected override void OnTargetReached()
    {
        // Flip enemy's vertical direction.
        FlipVertical();
    }

    // Get direction of enemy's movement.
    public Vector2 GetDirection()
    {
        // Return direction based on current movement.
        return isMovingTowardsTarget ? Vector2.up : Vector2.down;
    }

    // Flip enemy's vertical direction.
    private void FlipVertical()
    {
        // Update enemy's vertical scale.
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }

    // Adjust hitbox position based on enemy's movement direction.
    private void AjustHitbox()
    {
        // Set hitbox position based on direction.
        hitbox.transform.localPosition = new Vector3(0, Mathf.Sign(GetDirection().y) * 1f, 0);
    }
}