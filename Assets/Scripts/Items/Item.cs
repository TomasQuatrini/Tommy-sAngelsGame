using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item.cs
// Base class for all items in the game
// Provides a basic structure for items with a name, description, and use method

using UnityEngine;

public abstract class Item : ScriptableObject
{
    // Item name
    public string name;
    
    // Item description
    public string description;

    // Method to use the item
    public abstract void Use();

    public void Pickup(Inventory inventory)
    {
        inventory.PickupItem(this);
    }
}