using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DoorTrigger.cs
// A trigger that unlocks the door when the player collides with it

public class DoorTrigger : MonoBehaviour
{
    // Reference to the door script
    public Door door;

    // Called when the player collides with the door trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.tag == "Player")
        {
            // Unlock the door
            door.Unlock();
        }
    }
}