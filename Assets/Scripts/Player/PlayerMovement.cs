using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 5.0f; // Speed of movement. Editable speed in Unity
    private Rigidbody2D _rb2D; // Reference to the Rigidbody2D of the object
    private Vector2 _movementInput; // Create a movement vector
    private bool _isMoving;

    void Awake()
    {
        // Get the reference to the Rigidbody2D
        _rb2D = GetComponent<Rigidbody2D>();

        if (_rb2D == null)
        {
            Debug.LogError($"{name} has not Rigidbody2D");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            _isMoving = true;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            _movementInput = new Vector2(horizontal, vertical).normalized;
        }
        else
        {
            _isMoving = false;
            _movementInput = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            _rb2D.velocity = _movementInput * velocity;
        }
        else
        {
            _rb2D.velocity = Vector2.zero;
        }
    }

    private void HandleInput()
    {
        _movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void MovePlayer()
    {
        _rb2D.MovePosition(_rb2D.position + _movementInput.normalized * velocity * Time.fixedDeltaTime);
    }
}