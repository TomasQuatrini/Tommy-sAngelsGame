using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootArmOffSet : MonoBehaviour
{
    public float armDistance = 0.6f;
    private SpriteRenderer _sprite;
    private EnemyRangeMovement _movement;
    private Vector3 _originalScale;
    
    void Start()
    {
        _movement = GetComponentInParent<EnemyRangeMovement>();
        _sprite = GetComponent<SpriteRenderer>();
        _originalScale = transform.localScale;
    
    }
    void Update()
    {
        Vector2 dir = _movement.lastSightDir;
        if (dir.sqrMagnitude < 0.01f) return;

        float angle = Mathf.Atan2(dir.x, dir.x) * Mathf.Rad2Deg;

        transform.localPosition = new Vector3(dir.x * armDistance, dir.y * armDistance, transform.localPosition.z);

        float scaleX = dir.x < 0 ? -_originalScale.x : _originalScale.x;
        transform.localScale = new Vector3(scaleX, _originalScale.y, _originalScale.z);

        _sprite.sortingOrder = dir.y > 0 ? -1 : 1;
    }

}
