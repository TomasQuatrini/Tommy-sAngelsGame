using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    // Referencia al hitbox
    public Hitbox hitbox;

    // Cooldown entre ataques
    public float cooldown = 2f;

    // Indica si el enemigo puede atacar
    public bool canAttack = true;

    public void Attack(GameObject target)
    {
        Health health = target.GetComponentInChildren<Health>();

        if (health != null)
        {
            health.ReduceLife(10);
        }
        else
        {
            Debug.LogError("El objetivo no tiene una vida");
        }
    }

    public void ResetAttack()
    {
        // Activa la capacidad de atacar después del cooldown
        canAttack = true;
        // Desactiva el collider del hitbox
        hitbox.GetComponent<Collider2D>().enabled = false;
    }
}