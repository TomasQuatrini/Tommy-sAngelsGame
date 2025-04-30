using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    // Referencia al script de ataque
    public EnemyMeleeAttack attackScript;

    private bool playerInSight = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el jugador está dentro de la visión del enemigo
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInSight = true;
            StartCoroutine(AttackRoutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verifica si el jugador salió de la visión del enemigo
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInSight = false;
            StopAllCoroutines();
            attackScript.hitbox.GetComponent<Collider2D>().enabled = false;
            attackScript.hitbox.GetComponent<SpriteRenderer>().enabled = false;
            attackScript.canAttack = true;
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (playerInSight)
        {
            if (attackScript.canAttack)
            {
                // Activa el collider del hitbox
                attackScript.hitbox.GetComponent<Collider2D>().enabled = true;
                attackScript.hitbox.GetComponent<SpriteRenderer>().enabled = true;
                // Desactiva la capacidad de atacar durante el cooldown
                attackScript.canAttack = false;
                yield return new WaitForSeconds(attackScript.cooldown);
                // Desactiva el collider del hitbox
                attackScript.hitbox.GetComponent<Collider2D>().enabled = false;
                attackScript.hitbox.GetComponent<SpriteRenderer>().enabled = false;
                // Reactiva la capacidad de atacar
                attackScript.canAttack = true;
            }
            else
            {
                yield return null;
            }
        }
    }
}