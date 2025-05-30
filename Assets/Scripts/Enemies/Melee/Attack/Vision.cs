using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    // Reference to the attack script
    public EnemyMeleeAttack attackScript;

    // Reference to the movement script
    public EnemyMeleeMovement movementScript;

    private bool _playerInSight = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player is within the vision
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerInSight = true;
            movementScript.SetChasing(true);
            StartCoroutine(AttackRoutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the player has exited the vision
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerInSight = false;
            movementScript.SetChasing(false);
            StopAllCoroutines();
            attackScript.hitbox.GetComponent<Collider2D>().enabled = false;
            attackScript.hitbox.GetComponent<SpriteRenderer>().enabled = false;
            attackScript.canAttack = true;
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (_playerInSight)
        {
            if (attackScript.canAttack)
            {
                // Activate the hitbox collider
                attackScript.hitbox.GetComponent<Collider2D>().enabled = true;
                attackScript.hitbox.GetComponent<SpriteRenderer>().enabled = true;
                // Disable the ability to attack during the cooldown
                attackScript.canAttack = false;
                yield return new WaitForSeconds(attackScript.cooldown);
                // Deactivate the hitbox collider
                attackScript.hitbox.GetComponent<Collider2D>().enabled = false;
                attackScript.hitbox.GetComponent<SpriteRenderer>().enabled = false;
                // Reactivate the ability to attack
                attackScript.canAttack = true;
            }
            else
            {
                yield return null;
            }
        }
    }
}