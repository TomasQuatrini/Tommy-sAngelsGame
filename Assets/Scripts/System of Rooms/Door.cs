using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject destination; // Nivel destino
    public bool isLocked = false; // Estado de la puerta
    public bool useSpawnInit = true;
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Verificar si el jugador colisionó con la puerta
        if (collider.gameObject.tag == "Player")
        {
            // Verificar si la puerta está abierta
            if (!isLocked)
            {
                // Desactivar el nivel actual
                GameObject currentLevel = transform.parent.gameObject;
                currentLevel.SetActive(false);

                // Activar el nivel destino
                destination.SetActive(true);

                // Mover el jugador al punto de spawn inicial del nivel destino
                GameObject player = collider.gameObject;
                Transform spawnPoint = useSpawnInit ? destination.transform.Find("SpawnInit") : destination.transform.Find("SpawnEnd");
                if (spawnPoint != null)
                {
                    player.transform.position = spawnPoint.position;
                }
                else
                {
                    Debug.LogError("No se encontró el punto de spawn inicial en el nivel destino");
                }
            }
        }
    }
}