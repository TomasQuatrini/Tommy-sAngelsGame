using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 5.0f; // Speed of movement, editable in Unity inspector
    private Rigidbody2D _rb2D; // Reference to the Rigidbody2D component
    private Vector2 _movementInput; // Vector to store movement input
    private bool _isMoving; // Flag to track whether the player is moving

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D reference
        if (_rb2D == null) Debug.LogError($"{name} is missing a Rigidbody2D component"); // Log error if Rigidbody2D is missing
    }

    private void Update()
    {
        HandleInput(); // Update player input
    }

    private void FixedUpdate()
    {
        if (_isMoving) _rb2D.velocity = _movementInput * velocity; // Set Rigidbody2D velocity if moving
        else _rb2D.velocity = Vector2.zero; // Reset Rigidbody2D velocity if not moving
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            _isMoving = true; // Set moving flag to true
            float horizontal = Input.GetAxis("Horizontal"); // Get horizontal input
            float vertical = Input.GetAxis("Vertical"); // Get vertical input
            _movementInput = new Vector2(horizontal, vertical).normalized; // Create and normalize movement vector
        }
        else
        {
            _isMoving = false; // Set moving flag to false
            _movementInput = Vector2.zero; // Reset movement vector
        }
    }
}