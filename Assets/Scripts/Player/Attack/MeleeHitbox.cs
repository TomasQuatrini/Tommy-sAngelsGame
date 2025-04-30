using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    // Damage dealt to enemies
    public int damage = 10;

    // Offset for horizontal and vertical movements
    public float offsetHorizontal = 0.5f;
    public float offsetVertical = 0.7f;

    // Reference to the player attack script
    public PlayerAttack playerAttack;

    // Last movement direction
    private Vector2 _lastMovementDirection;

    // Last hitbox position
    private Vector3 _lastDirection = new Vector3(0, 0.7f, 0);

    private void Update()
    {
        // Get the input direction
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Update the last movement direction
        if (horizontalInput != 0 || verticalInput != 0)
        {
            _lastMovementDirection = new Vector2(horizontalInput, verticalInput).normalized;
        }

        // Update the hitbox position
        UpdateHitboxPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Apply damage to enemies
        if (collision.CompareTag("Enemies"))
        {
            playerAttack.Attack(collision.gameObject);
        }
    }

    private Vector3 GetDirection(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                return new Vector3(offsetHorizontal, 0, 0);
            }
            else
            {
                return new Vector3(-offsetHorizontal, 0, 0);
            }
        }
        else
        {
            if (direction.y > 0)
            {
                return new Vector3(0, offsetVertical, 0);
            }
            else
            {
                return new Vector3(0, -offsetVertical, 0);
            }
        }
    }

    public void UpdateHitboxPosition()
    {
        _lastDirection = GetDirection(_lastMovementDirection);
        transform.localPosition = _lastDirection;
    }
}