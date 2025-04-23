using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Key.cs
// A key item

[CreateAssetMenu(fileName = "New Key", menuName = "Items/Key")]
public class Key : Item
{
    // Unique ID for the key
    public string keyId;

    // Use the key
    public override void Use()
    {
        // The logic for using the key will be implemented in the door
    }
}