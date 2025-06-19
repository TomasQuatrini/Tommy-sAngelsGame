using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    private Vector2 _direction;
    private PlayerMovement _movement;
    public float fireCooldown    = 0.5f;
    public float projectileSpeed = 5f;
    private float lastFireTime;

    private void Start()
    {
        _movement = GetComponentInParent<PlayerMovement>();
    }
    public void Attack(Vector2 dir)
    {
        if (Time.time < lastFireTime + fireCooldown)
            return;

        lastFireTime = Time.time;
        if (dir.sqrMagnitude < 0.01f)
        {
            dir = Vector2.down;
        }

        // Instantiate and launch projectile
        GameObject proj = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        Projectile projScript = proj.GetComponent<Projectile>();
        if (projScript != null)
        {
            projScript.currentFlag = Projectile.FlagAttack.Player;
        }
        Rigidbody2D rb   = proj.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = dir * projectileSpeed;
    }

    private void Update()
    {
        if (_movement.MovementDirection.sqrMagnitude > 0.01f)
        {
            _direction = _movement.MovementDirection.normalized;
        }
        Attack(_direction);
    }

    private void OnEnable()
    {
        _direction = _movement.MovementDirection.normalized;
    }

    private void OnDisable()
    {
        _direction = _movement.MovementDirection.normalized;
    }
}
