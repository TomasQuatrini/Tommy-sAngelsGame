using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootArmOffSet : MonoBehaviour
{
    private Transform _transform;
    private SpriteRenderer _sprite;
    private EnemyRangeMovement _enemyRangeMovement;
    private Vector2 _agent;
    private float _offsetH = 0.5f;
    private float _offsetV = 0.59f;
    
    void Start()
    {
        _enemyRangeMovement = GetComponentInParent<EnemyRangeMovement>();
        _transform = GetComponent<Transform>();
        _sprite = GetComponent<SpriteRenderer>();
    
    }
    void Update()
    {
        _agent = _enemyRangeMovement.Lastdirection;
        UpdateHitboxPosition();
    }
    public void UpdateHitboxPosition()
    {
        if (_agent.x > Mathf.Abs(_agent.y))
        {
            _sprite.sortingOrder = 1;
            _transform.localPosition = new Vector3(_offsetH, -0.59f, 0);
            _transform.localScale = new Vector3(1, 1, 1);
            _transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_agent.x < -Mathf.Abs(_agent.y))
        {
            _sprite.sortingOrder = 1;
            _transform.localPosition = new Vector3(-_offsetH, -0.59f, 0);
            _transform.localScale = new Vector3(-1, 1, 1);
            _transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_agent.y > Mathf.Abs(_agent.x))
        {
            _sprite.sortingOrder = -1;
            _transform.localPosition = new Vector3(0, _offsetV, 0);
            _transform.localScale = new Vector3(1, 1, 1);
            _transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            _sprite.sortingOrder = 1;
            _transform.localPosition = new Vector3(_offsetH, -_offsetV, 0);
            _transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
