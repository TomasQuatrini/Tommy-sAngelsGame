using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject destination; // level destine
    public bool isLocked = false; // state of door
    public bool useSpawnInit = true; // use spawninit or spawnend
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Verify collide with player
        if (collider.gameObject.tag == "Player")
        {
            // Check if the door is open
            if (!isLocked)
            {
                // Deactivate the current level
                GameObject currentLevel = transform.parent.gameObject;
                currentLevel.SetActive(false);

                // Activate level destine
                destination.SetActive(true);

                // Transport player to lvl destine
                GameObject player = collider.gameObject;
                Transform spawnPoint = useSpawnInit ? destination.transform.Find("SpawnInit") : destination.transform.Find("SpawnEnd");
                if (spawnPoint != null)
                {
                    player.transform.position = spawnPoint.position;
                }
                else
                {
                    Debug.LogError("Initial spawn point not found on destination level");
                }
            }
        }
    }
}