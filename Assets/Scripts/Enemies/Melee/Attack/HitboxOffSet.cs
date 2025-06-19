using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HitboxOffSet : MonoBehaviour
{
    private EnemyMeleeMovement _movement;
    private float _offsetH = 0.5f;
    private float _offsetV = 1f;
    private Transform _transform;
    private SpriteRenderer _sprite;
    private NavMeshAgent _agent;

    private Vector2 _input;
    private Vector2 _lastDirection = Vector2.down;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _agent = GetComponentInParent<NavMeshAgent>();
        _sprite = GetComponent<SpriteRenderer>();
        _movement = GetComponentInParent<EnemyMeleeMovement>();
    }

    void Update()
    {
        _input = _movement.GetVelocity();

        // Si no hay input (está quieto), usamos la última dirección guardada
        Vector2 dir = _input.sqrMagnitude > 0.01f 
            ? _input.normalized 
            : _lastDirection;

        UpdateHitboxPosition(dir);
    }

    public void UpdateHitboxPosition(Vector2 dir)
    {
        // Guardamos para la próxima vez
        _lastDirection = dir;

        // Ahora usamos 'dir' para posicionar y rotar
        if (dir.x > Mathf.Abs(dir.y))
        {
            _sprite.sortingOrder = -1;
            _transform.localPosition = new Vector3(_offsetH, -0.16f, 0);
            _transform.rotation = Quaternion.Euler(0, 0, 0);
            _transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dir.x < -Mathf.Abs(dir.y))
        {
            _sprite.sortingOrder = -1;
            _transform.localPosition = new Vector3(-_offsetH, -0.16f, 0);
            _transform.rotation = Quaternion.Euler(0, 0, 0);
            _transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (dir.y > Mathf.Abs(dir.x))
        {
            _sprite.sortingOrder = -1;
            _transform.localPosition = new Vector3(0, _offsetV, 0);
            _transform.rotation = Quaternion.Euler(0, 0, 90);
            _transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            _sprite.sortingOrder = 1;
            _transform.localPosition = new Vector3(0, -_offsetV, 0);
            _transform.rotation = Quaternion.Euler(0, 0, -90);
            _transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void OnDisable()
    {
        _lastDirection = _movement.GetVelocity().normalized;
    }
}
