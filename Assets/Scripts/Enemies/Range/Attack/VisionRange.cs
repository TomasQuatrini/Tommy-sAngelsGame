using UnityEngine;

/// <summary>
/// Attach this to a child GameObject with Collider2D (isTrigger) to detect the player.
/// Performs a raycast to ensure no obstacles block line of sight.
/// </summary>
public class VisionRange : MonoBehaviour
{
    [Header("Obstacle Layers")]
    public LayerMask obstacleMask;
    [Header("Player Tag")]
    public string playerTag = "Player";

    private EnemyRangeMovement movement;
    private EnemyRangeAttack attack;

    void Start()
    {
        movement = GetComponentInParent<EnemyRangeMovement>();
        attack   = GetComponentInParent<EnemyRangeAttack>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (!other.CompareTag(playerTag)) 
        {
            return;
        }
        Vector2 origin    = transform.position;
        Vector2 targetPos = other.transform.position;
        Vector2 dir       = (targetPos - origin).normalized;
        movement._lastdirection = dir;
        float   dist      = Vector2.Distance(origin, targetPos);

        // Raycast to detect obstacles
        RaycastHit2D hit = Physics2D.Raycast(origin, dir, dist, obstacleMask);
        bool clearSight = (hit.collider == null);

        movement.SetCanSeePlayer(clearSight);

        if (clearSight)
        {
            attack.Attacking(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            attack.NotAttacking();
            movement.SetCanSeePlayer(false);
        }
    }
}