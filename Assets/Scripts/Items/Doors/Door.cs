using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Door.cs
// A door that can be unlocked with a key

public class Door : MonoBehaviour
{
    // ID of the key required to unlock the door
    public string requiredKeyId;

    // Reference to the player's inventory
    public Inventory inventory;

    // Unlock the door
    public void Unlock()
    {
        // Find the key in the player's inventory
        Key key = inventory.items.Find(item => item is Key && ((Key)item).keyId == requiredKeyId) as Key;
        if (key != null)
        {
            // Unlock the door
            Debug.Log("Door unlocked");
            // Deactivate the door GameObject
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("You don't have the required key");
        }
    }
}