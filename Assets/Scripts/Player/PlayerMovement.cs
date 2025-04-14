using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField] private float velocity = 5.0f; // Speed of movement. Editable speed in Unity
    private Rigidbody2D _rb2D; // Reference to the Rigidbody2D of the object
    private Vector2 _movementInput; // Create a movement vector

    void Awake()
    {
        // Get the reference to the Rigidbody2D
        _rb2D = GetComponent<Rigidbody2D>();
        
        if (_rb2D == null)
        {
            Debug.LogError($"{name} has not Rigidbody2D");
        }
    }
    
    void Update()
    {
        HandleInput(); // Read keyboard inputs
    }

    void FixedUpdate()
    {
        MovePlayer(); // Apply movement to Rigidbody2D with velocity
    }

    private void HandleInput()
    {
        _movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Debug.Log($"Movement: {_movementInput}");
    }

    private void MovePlayer()
    {
        _rb2D.velocity = _movementInput.normalized * velocity;
    }
}