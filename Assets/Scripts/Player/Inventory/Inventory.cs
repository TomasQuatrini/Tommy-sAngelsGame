// Inventory.cs
// Manages the player's inventory
// Allows adding, removing, and using items

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // List of items in the inventory
    public List<Item> items = new List<Item>();
    
    // Maximum number of slots in the inventory
    public int maxSlots;

    // Add an item to the inventory
    public bool AddItem(Item item)
    {
        // Check if there is space in the inventory
        if (items.Count < maxSlots)
        {
            items.Add(item);
            return true;
        }
        else 
        {
            return false;
        }
    }

    // Remove an item from the inventory
    public bool RemoveItem(Item item)
    {
        // Check if the item exists in the inventory
        if (items.Contains(item))
        {
            items.Remove(item);
            return true;
        }
        else
        {
            Debug.Log("Item not found in inventory");
            return false;
        }
    }

    // Use an item in the inventory
    public void UseItem(Item item)
    {
        // Check if the item exists in the inventory
        if (items.Contains(item))
        {
            item.Use();
        }
        else
        {
            Debug.Log("Item not found in inventory");
        }
    }

    // Pickup an item and add it to the inventory
    public void PickupItem(Item item)
    {
        AddItem(item);
        // You can add additional logic here, such as destroying the item's GameObject
    }
}