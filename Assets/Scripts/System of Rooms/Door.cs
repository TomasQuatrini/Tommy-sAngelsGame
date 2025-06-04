using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject destination; // level destine
    public bool isLocked = false; // state of door
    public string keyId = "lvl1";
    public int selectedSpawnIndex;
    public Inventory inventory;
    private Transform[] _spawnPoints;
    private string _spawnContainerName = "Spawn";

    private void InitializeSpawnPoints()
    {
        // Find GameObject child in 
        Transform spawnContainer = destination.transform.Find(_spawnContainerName);
        if (spawnContainer == null)
        {
            foreach (Transform child in destination.transform)
            {
                if (child.name.ToLower() == _spawnContainerName.ToLower())
                {
                    spawnContainer = child;
                    break;
                }
            }
        }

        if (spawnContainer != null)
        {
            _spawnPoints = new Transform[spawnContainer.childCount];
            for (int i = 0; i < spawnContainer.childCount; i++)
            {
                _spawnPoints[i] = spawnContainer.GetChild(i);
            }
        }
        else
        {
            Debug.LogError("spawn container no avaible");
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check collision with the player
        if (collider.gameObject.tag == "Player")
        {
            if (!isLocked)
            {
                // Deactivate the current level
                GameObject currentLevel = transform.parent.gameObject;
                currentLevel.SetActive(false);

                // Activate level destine
                destination.SetActive(true);
                InitializeSpawnPoints();

                // Transport player
                GameObject player = collider.gameObject;
                player.transform.position = _spawnPoints[selectedSpawnIndex].position;
            }
            else
            {
                Debug.Log("You haven't key");
            }
        }
    }

    public void Unlocked()
    {
        isLocked = false;
    }
}