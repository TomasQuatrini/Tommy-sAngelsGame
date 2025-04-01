using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   // Speed of movement
    public float velocity = 5.0f;

    // Reference to the Rigidbody2D of the object
    private Rigidbody2D _rb;

    void Start()
    {
        // Get the reference to the Rigidbody2D
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Read keyboard inputs
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector2 movement = new Vector2(movementHorizontal, movementVertical);

        // Apply movement to the Rigidbody2D
        _rb.MovePosition(_rb.position + movement * velocity * Time.deltaTime);
    }
}