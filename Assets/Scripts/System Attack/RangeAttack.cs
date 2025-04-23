using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that implements the ranged attack state
public class RangedAttack : AttackState
{
    // Method that is called when a ranged attack is performed
    public override void Attack(GameObject attacker, GameObject target, IHealth health, int damage)
    {
        if (health != null)
        {
            // Logic to perform a ranged attack
            health.ReduceLife(damage);
            Debug.Log("Ranged attack performed");
        }
        else
        {
            Debug.LogError("El objetivo no tiene un componente de salud");
        }
    }
}
