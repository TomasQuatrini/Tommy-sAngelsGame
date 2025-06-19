using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player movement.
public class PlayerMovement : MonoBehaviour
{
    // Player movement speed.
    [SerializeField] private float _velocity = 5.0f;

    // Rigidbody2D reference.
    private Rigidbody2D _rb2D;
    private Animator _animator;

    // Movement input.
    private Vector2 _movementInput;

    // Flag to check if player is being pushed.
    public bool isBeingPushed = false;
    public Vector2 MovementDirection => _movementInput.normalized;  

    // Duration of push.
    public float pushDuration = 0.4f;

    // Initialize Rigidbody2D component.
    void Awake()
    {
        // Get Rigidbody2D component.
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        // Check if Rigidbody2D component is missing.
        if (_rb2D == null)
        {
            Debug.LogError("Rigidbody2D component is missing");
        }
    }

    // Handle input.
    void Update()
    {
        // Get movement input.
        HandleInput();
    }

    // Move player.
    void FixedUpdate()
    {
        // Update player position.
        MovePlayer();
        SetAnimator();
    }

    // Get movement input from player.
    private void HandleInput()
    {
        // Get horizontal and vertical input.
        _movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public Vector2 GetInput()
    {
        return _movementInput.normalized;
    }

    // Move player based on input.
    private void MovePlayer()
    {
        // Check if player is not being pushed.
        if (!isBeingPushed)
        {
            // Set player velocity.
            _rb2D.velocity = _movementInput.normalized * _velocity;
        }
    }

    // Push player.
    public void PushPlayer()
    {
        // Set flag to true.
        isBeingPushed = true;

        // Stop pushing after duration.
        Invoke("StopPushing", pushDuration);
    }

    // Stop pushing player.
    private void StopPushing()
    {
        // Set flag to false.
        isBeingPushed = false;
    }

    private void SetAnimator()
    {
        _animator.SetFloat("VelocityX", _rb2D.velocity.x);
        _animator.SetFloat("VelocityY", _rb2D.velocity.y);
        if (_rb2D.velocity.magnitude == 0)
        {
            _animator.SetBool("IsIddle?", true);
        }
        else
        {
            _animator.SetBool("IsIddle?", false);
        }
    }
}