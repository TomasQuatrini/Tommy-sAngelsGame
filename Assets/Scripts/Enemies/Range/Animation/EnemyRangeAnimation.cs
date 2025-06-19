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

    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<EnemyRangeMovement>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector2 velocity = _agent.velocity; 
        Vector2 lookDir;
        if (velocity.magnitude > 0.05f)
        {
            if (velocity.magnitude > 0.05f && !_movement.Stopped)
            {
                // Caminando
                lookDir = velocity.normalized;
                PlayWalkAnimation(lookDir);
            }
            else
            {
                // Quieto: usar última dirección de visión para orientar el idle/ataque
                lookDir = _movement.lastSightDir;
                PlayIdleAnimation(lookDir);
            }
        }
    }

    void PlayWalkAnimation(Vector2 dir)
    {
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            _animator.Play("WalkR-LYag");
        else if (dir.y > 0)
            _animator.Play("WalkBackYag");
        else
            _animator.Play("WalkFrontYag");
    }

    void PlayIdleAnimation(Vector2 dir)
    {
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            _animator.Play("IddleR-LYag");
        else if (dir.y > 0)
            _animator.Play("IddleTopYag");
        else
            _animator.Play("IddleDownYag");
    }
}