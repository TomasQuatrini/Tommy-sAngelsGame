using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    // Reference to the key scriptable object
    public Key key;

    // Reference to the player's inventory
    public Inventory inventory;
    public Door door;
    // Called when the player collides with the key
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.tag == "Player")
        {
            // Add the key to the player's inventory
            inventory.AddItem(key);
            // Destroy the key GameObject
            Destroy(gameObject);
            door.Unlocked();            
        }
    }
    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void SpawnKey()
    {
        // Instantiate the key GameObject
        gameObject.SetActive(true);
    }
}