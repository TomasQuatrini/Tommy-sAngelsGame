using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeMovement : MonoBehaviour
{
    // Patrol points
    private Transform[] patrolPointTransforms;
    private Vector2[] patrolPoints;

    // Reference to the navigation agent
    private NavMeshAgent agent;
    private EnemyMeleeHealth health;

    // Current patrol point index
    private int currentPatrolIndex = 0;

    // Vision transform
    private Transform visionTransform;
    private Transform hitboxTransform;

    private bool isChasing = false;

    private void Start()
    {
        health = GetComponent<EnemyMeleeHealth>();
        // Initialize patrol points
        InitPatrolPoints();

        // Disable patrol point sprite renderers
        DisableSR();

        // Get patrol point positions
        GetZonePatrol();

        // Initialize navigation agent
        InitNavigation();

        // Find vision transform
        FindVision();

        // Find hitbox transform
        FindHitbox();

        // Set initial destination
        agent.SetDestination(new Vector3(patrolPoints[currentPatrolIndex].x, patrolPoints[currentPatrolIndex].y, transform.position.z));
    }

    private void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            FlipPatrol();
        }
        AdjustVision();
        FlipSprite();
    }

    public void SetChasing(bool chasing)
    {
        if (health.IsAlive())
        {
            isChasing = chasing;
            if (!chasing)
            {
                agent.SetDestination(new Vector3(patrolPoints[currentPatrolIndex].x, patrolPoints[currentPatrolIndex].y, transform.position.z));
            }
        }
    }

    private void FlipPatrol()
    {
        // Check if we've reached the current patrol point
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), patrolPoints[currentPatrolIndex]) < 0.1f)
        {
            // Move to the next patrol point
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(new Vector3(patrolPoints[currentPatrolIndex].x, patrolPoints[currentPatrolIndex].y, transform.position.z));
        }
    }

    private void AdjustVision()
    {
        if (agent.velocity.x > Mathf.Abs(agent.velocity.y))
        {
            visionTransform.rotation = Quaternion.Euler(0, 0, 180);
            hitboxTransform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (agent.velocity.x < -Mathf.Abs(agent.velocity.y))
        {
            visionTransform.rotation = Quaternion.Euler(0, 0, 0);
            hitboxTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (agent.velocity.y > Mathf.Abs(agent.velocity.x))
        {
            visionTransform.rotation = Quaternion.Euler(0, 0, -90);
            hitboxTransform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else
        {
            visionTransform.rotation = Quaternion.Euler(0, 0, 90);
            hitboxTransform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    private void ChasePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    public Vector2 GetVelocity()
    {
        return new Vector2(agent.velocity.x, agent.velocity.y);
    }

    private void DisableSR()
    {
        foreach (Transform patrolPoint in patrolPointTransforms)
        {
            patrolPoint.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void GetZonePatrol()
    {
        if (patrolPointTransforms != null && patrolPointTransforms.Length >= 2)
        {
            patrolPoints = new Vector2[2];
            patrolPoints[0] = new Vector2(patrolPointTransforms[0].position.x, patrolPointTransforms[0].position.y);
            patrolPoints[1] = new Vector2(patrolPointTransforms[1].position.x, patrolPointTransforms[1].position.y);
        }
        else
        {
            Debug.LogError("Patrol points not initialized correctly");
        }
    }

    private void InitNavigation()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void InitPatrolPoints()
    {
        patrolPointTransforms = new Transform[2];
        patrolPointTransforms[0] = transform.Find("Points/Point1").transform;
        patrolPointTransforms[1] = transform.Find("Points/Point2").transform;
    }

    private void FindVision()
    {
        visionTransform = transform.Find("Vision");
        if (visionTransform == null)
        {
            Debug.LogError("Vision GameObject not found");
        }
    }

    private void FindHitbox()
    {
        hitboxTransform = transform.Find("HitboxE");
        if (hitboxTransform == null)
        {
            Debug.LogError("Hitbox GameObject not found");
        }
    }

    private void FlipSprite()
    {
        if (agent.velocity.x > 0)
        {
            // Movement upwards
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (agent.velocity.x < 0)
        {
            // Movement downwards
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}