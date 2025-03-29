using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   // Speed of movement
    public float velocidad = 5.0f;

    // Reference to the Rigidbody2D of the object
    private Rigidbody2D rb;

    void Start()
    {
        // Get the reference to the Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Read keyboard inputs
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector2 movimiento = new Vector2(movimientoHorizontal, movimientoVertical);

        // Apply movement to the Rigidbody2D
        rb.MovePosition(rb.position + movimiento * velocidad * Time.deltaTime);
    }
}