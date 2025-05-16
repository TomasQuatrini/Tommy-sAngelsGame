using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject destination; // level destine
    public bool isLocked = false; // state of door
    public string spawnContainerName = "Spawn"; 
    private Transform[] _spawnPoints;
    public int selectedSpawnIndex;
    private void InitializeSpawnPoints()
    {
        // Find GameObject child in 
        Transform spawnContainer = destination.transform.Find(spawnContainerName);
        if (spawnContainer == null)
        {
            foreach (Transform child in destination.transform)
            {
                if (child.name.ToLower() == spawnContainerName.ToLower())
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
            Debug.LogError("Contenedor de puntos de spawn no encontrado en el nivel destino");
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Verificar colisión con el jugador
        if (collider.gameObject.tag == "Player")
        {
            // is Locked?
            if (!isLocked)
            {
                // Desactivar el nivel actual
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
                Debug.Log("You need a key");
            }
        }
    }
}