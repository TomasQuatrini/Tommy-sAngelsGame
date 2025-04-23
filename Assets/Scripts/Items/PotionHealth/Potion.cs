using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public HealthPotion healthPotion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Usa la poción
            healthPotion.Use();
            // Destruye el GameObject de la poción
            Destroy(gameObject);
        }
    }
}
