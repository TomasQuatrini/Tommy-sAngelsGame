using UnityEngine;
using UnityEngine.AI;

public class EnemyRangeMovement : MonoBehaviour
{
    [Header("Patrol Points")]
    private Transform[] _patrolPointTransforms;
    private Vector2[] _patrolPoints;
    [Header("Movement")]
    public float patrolSpeed = 2f;
    private int _currentPatrolIndex = 0;

    private NavMeshAgent agent;
    private Transform currentTarget;
    private bool canSeePlayer = false;
    public Vector2 _lastdirection { get; set; }

    public Vector2 Lastdirection { get { return _lastdirection;}}


    void Start()
    {
        InitPatrolPoints();
        DisableSR();
        GetZonePatrol();
        InitNavigation();
        agent.SetDestination(new Vector3(_patrolPoints[_currentPatrolIndex].x, _patrolPoints[_currentPatrolIndex].y, transform.position.z));
    }

    void Update()
    {
        if (agent.velocity.magnitude > 0.05f)
        {
            _lastdirection = agent.velocity;
        }
        if (canSeePlayer)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
            FlipPatrol();
        }

        // Flip sprite based on movement direction
        FlipSprite();
    }
    private void FlipPatrol()
    {
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), _patrolPoints[_currentPatrolIndex]) < 0.1f)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
            agent.SetDestination(new Vector3(_patrolPoints[_currentPatrolIndex].x, _patrolPoints[_currentPatrolIndex].y, transform.position.z));
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
    private void InitPatrolPoints()
    {
        _patrolPointTransforms = new Transform[2];
        _patrolPointTransforms[0] = transform.Find("Points/Point1").transform;
        _patrolPointTransforms[1] = transform.Find("Points/Point2").transform;
    }

    public void SetCanSeePlayer(bool isVisible)
    {
        canSeePlayer = isVisible;
    }
    private void DisableSR()
    {
        foreach (Transform patrolPoint in _patrolPointTransforms)
        {
            patrolPoint.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void FlipSprite()
    {
        Vector2 dir = agent.velocity.magnitude > 0.05f ? agent.velocity : _lastdirection;
        if (dir.x > 0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir.x < -0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void InitNavigation()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void OnEnable()
    {
        if (!canSeePlayer && _patrolPoints != null && _patrolPoints.Length > 0 && agent != null)
        {
            agent.SetDestination(new Vector3(_patrolPoints[_currentPatrolIndex].x, _patrolPoints[_currentPatrolIndex].y, transform.position.z));
        }
    }
}