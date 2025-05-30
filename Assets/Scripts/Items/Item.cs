using System.Collections;
using System.Collections.Generic;
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