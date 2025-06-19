using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public int numberDoors = 1;
    public Door door1;
    public Door door2;
    public Door door3;
    // Called when the player collides with the key
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.tag == "Player")
        {
            // Destroy the key GameObject
            Destroy(gameObject);
            door1.Unlocked();
            if (numberDoors == 2)
            {
                door2.Unlocked();
            }
            if (numberDoors == 3)
            {
                door2.Unlocked();
                door3.Unlocked();
            }            
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