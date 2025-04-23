using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    // Reference to the key GameObject
    public GameObject keyObject;

    // Number of enemies that need to be killed before the key spawns
    public int enemiesToKill = 1;

    // Current number of enemies killed
    private int enemiesKilled = 0;

    public void Start()
    {
        keyObject.SetActive(false);
    }

    // Spawn the key
    public void SpawnKey()
    {
        // Instantiate the key GameObject
        keyObject.SetActive(true);
    }

    // Increment the number of enemies killed
    public void EnemyKilled()
    {
        enemiesKilled++;
        // Check if the number of enemies killed is equal to the required number
        if (enemiesKilled >= enemiesToKill)
        {
            SpawnKey();
        }
    }
}