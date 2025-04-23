using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    public int damage = 10;
    public float offset = 0.35f;
    public PlayerAttack playerAttack;
    private Vector3 _lastDirection;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        Orientation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            // Apply damage to player.
            playerAttack.Attack(collision.gameObject);
        }
    }
    private void Orientation()
    {
        PlayerMovement playerMovement = GetComponentInParent<PlayerMovement>();
        Vector2 movementDirection = playerMovement.MovementDirection;

        if (movementDirection != Vector2.zero)
        {
            if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
            {
                if (movementDirection.x > 0)
                {
                    transform.localPosition = new Vector3(offset, 0, 0);
                    _lastDirection = transform.localPosition;
                }
                else
                {
                    transform.localPosition = new Vector3(-offset, 0, 0);
                    _lastDirection = transform.localPosition;
                }
            }
            else
            {
                if (movementDirection.y > 0)
                {
                    transform.localPosition = new Vector3(0, offset, 0);
                    _lastDirection = transform.localPosition;
                }
                else
                {
                    transform.localPosition = new Vector3(0, -offset, 0);
                    _lastDirection = transform.localPosition;
                }
            }
        }
        else
        {
            transform.localPosition = _lastDirection;
        }
    }
}