using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class EnemyRangeAnimation : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;
    private EnemyRangeMovement _movement;
    private Vector2 _lastDirection;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<EnemyRangeMovement>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector2 velocity = _agent.velocity; 
        if (velocity.magnitude > 0.05f)
        {
            _lastDirection = velocity;
            // Elegimos animación según dirección
            if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
            {
                _animator.Play("WalkR-LYag");
            }
            else if (velocity.y > 0)
            {
                _animator.Play("WalkBackYag");
            }
            else
            {
                _animator.Play("WalkFrontYag");
            }
        }
        else
        {
            _lastDirection = _movement.Lastdirection;
            if (Mathf.Abs(_lastDirection.x) > Mathf.Abs(_lastDirection.y))
            {
                _animator.Play("IddleR-LYag");
            }
            else if (_lastDirection.y > 0)
            {
                _animator.Play("IddleTopYag");
            }
            else
            {
                _animator.Play("IddleDownYag");
            }
        }
    }
}