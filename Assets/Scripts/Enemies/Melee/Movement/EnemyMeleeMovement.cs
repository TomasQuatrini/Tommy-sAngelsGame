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

    // Current patrol point index
    private int currentPatrolIndex = 0;

    // Vision transform
    private Transform visionTransform;
    private Transform hitboxTransform;

    private void Start()
    {
        // Initialize patrol points
        patrolPointTransforms = new Transform[2];
        patrolPointTransforms[0] = transform.Find("Points/Point1").transform;
        patrolPointTransforms[1] = transform.Find("Points/Point2").transform;

        // Disable patrol point sprite renderers
        foreach (Transform patrolPoint in patrolPointTransforms)
        {
            patrolPoint.GetComponent<SpriteRenderer>().enabled = false;
        }

        // Get patrol point positions
        patrolPoints = new Vector2[2];
        patrolPoints[0] = new Vector2(patrolPointTransforms[0].position.x, patrolPointTransforms[0].position.y);
        patrolPoints[1] = new Vector2(patrolPointTransforms[1].position.x, patrolPointTransforms[1].position.y);

        // Initialize navigation agent
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // Find vision transform
        visionTransform = transform.Find("Vision");
        if (visionTransform == null)
        {
            Debug.LogError("Vision GameObject not found");
        }
        hitboxTransform = transform.Find("HitboxE");
        if (hitboxTransform == null)
        {
            Debug.LogError("Hitbox GameObject not found");
        }

        // Set initial destination
        agent.SetDestination(new Vector3(patrolPoints[currentPatrolIndex].x, patrolPoints[currentPatrolIndex].y, transform.position.z));
    }

    private void Update()
    {
        FlipPatrol();
        AdjustVision();
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
        Vector2 direction = new Vector2(agent.velocity.x, agent.velocity.y).normalized;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                visionTransform.localScale = new Vector3(-1, 1, 1);
                hitboxTransform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                visionTransform.localScale = new Vector3(1, 1, 1);
                hitboxTransform.localScale = new Vector3(1, 1, 1); 
            }
        }
        else if (direction.y > 0)
        {
            // Si se mueve hacia arriba, mantener la orientación actual
            // No es necesario cambiar la escala
        }
        else if (direction.y < 0)
        {
            // Si se mueve hacia abajo, mantener la orientación actual
            // No es necesario cambiar la escala
        }
    }

    public Vector2 GetVelocity()
    {
        return new Vector2(agent.velocity.x, agent.velocity.y);
    }
}