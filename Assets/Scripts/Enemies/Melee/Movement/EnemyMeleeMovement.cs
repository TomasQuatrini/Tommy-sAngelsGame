using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeMovement : MonoBehaviour
{
    // Patrol points
    private Transform[] _patrolPointTransforms;
    private Vector2[] _patrolPoints;

    // Reference to the navigation agent
    private NavMeshAgent _agent;
    private EnemyMeleeHealth _health;

    // Current patrol point index
    private int _currentPatrolIndex = 0;

    // Vision and hitbox transforms
    private Transform _visionTransform;
    private Transform _hitboxTransform;

    private bool _isChasing = false;

    private void Start()
    {
        _health = GetComponent<EnemyMeleeHealth>();
        InitPatrolPoints();
        DisableSR();
        GetZonePatrol();
        InitNavigation();
        FindVision();
        FindHitbox();

        _agent.SetDestination(new Vector3(_patrolPoints[_currentPatrolIndex].x, _patrolPoints[_currentPatrolIndex].y, transform.position.z));
    }

    private void Update()
    {
        if (_isChasing)
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
        if (_health.IsAlive())
        {
            _isChasing = chasing;
            if (!chasing)
            {
                _agent.SetDestination(new Vector3(_patrolPoints[_currentPatrolIndex].x, _patrolPoints[_currentPatrolIndex].y, transform.position.z));
            }
        }
    }

    private void FlipPatrol()
    {
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), _patrolPoints[_currentPatrolIndex]) < 0.1f)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
            _agent.SetDestination(new Vector3(_patrolPoints[_currentPatrolIndex].x, _patrolPoints[_currentPatrolIndex].y, transform.position.z));
        }
    }

    private void AdjustVision()
    {
        if (_agent.velocity.x > Mathf.Abs(_agent.velocity.y))
        {
            _visionTransform.rotation = Quaternion.Euler(0, 0, 180);
            _hitboxTransform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (_agent.velocity.x < -Mathf.Abs(_agent.velocity.y))
        {
            _visionTransform.rotation = Quaternion.Euler(0, 0, 0);
            _hitboxTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_agent.velocity.y > Mathf.Abs(_agent.velocity.x))
        {
            _visionTransform.rotation = Quaternion.Euler(0, 0, -90);
            _hitboxTransform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else
        {
            _visionTransform.rotation = Quaternion.Euler(0, 0, 90);
            _hitboxTransform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    private void ChasePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _agent.SetDestination(player.transform.position);
        }
    }

    public Vector2 GetVelocity()
    {
        return new Vector2(_agent.velocity.x, _agent.velocity.y);
    }

    private void DisableSR()
    {
        foreach (Transform patrolPoint in _patrolPointTransforms)
        {
            patrolPoint.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void GetZonePatrol()
    {
        if (_patrolPointTransforms != null && _patrolPointTransforms.Length >= 2)
        {
            _patrolPoints = new Vector2[2];
            _patrolPoints[0] = new Vector2(_patrolPointTransforms[0].position.x, _patrolPointTransforms[0].position.y);
            _patrolPoints[1] = new Vector2(_patrolPointTransforms[1].position.x, _patrolPointTransforms[1].position.y);
        }
        else
        {
            Debug.LogError("Patrol points not initialized correctly");
        }
    }

    private void InitNavigation()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void InitPatrolPoints()
    {
        _patrolPointTransforms = new Transform[2];
        _patrolPointTransforms[0] = transform.Find("Points/Point1").transform;
        _patrolPointTransforms[1] = transform.Find("Points/Point2").transform;
    }

    private void FindVision()
    {
        _visionTransform = transform.Find("Vision");
        if (_visionTransform == null)
        {
            Debug.LogError("Vision GameObject not found");
        }
    }

    private void FindHitbox()
    {
        _hitboxTransform = transform.Find("HitboxE");
        if (_hitboxTransform == null)
        {
            Debug.LogError("Hitbox GameObject not found");
        }
    }

    private void FlipSprite()
    {
        if (_agent.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (_agent.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnEnable()
    {
        if (!_isChasing && _patrolPoints != null && _patrolPoints.Length > 0 && _agent != null)
        {
            _agent.SetDestination(new Vector3(_patrolPoints[_currentPatrolIndex].x, _patrolPoints[_currentPatrolIndex].y, transform.position.z));
        }
    }
}