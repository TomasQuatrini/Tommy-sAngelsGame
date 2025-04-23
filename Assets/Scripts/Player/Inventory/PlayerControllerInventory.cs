// PlayerControllerInventory.cs
// Manages the player's inventory interaction
// Allows the player to pickup items

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerInventory : MonoBehaviour
{
    // Reference to the player's inventory
    public Inventory inventory;

    // Called when the player collides with an item
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is an item
        if (other.gameObject.tag == "Item")
        {
            // Get the item component
            Item item = other.gameObject.GetComponent<Item>();
            if (item != null)
            {
                // Pickup the item and add it to the inventory
                inventory.PickupItem(item);
                Destroy(other.gameObject); // Destroy the item's GameObject
            }
        }
    }
}