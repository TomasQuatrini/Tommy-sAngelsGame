using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that implements the melee attack state
public class MeleeAttack : AttackState
{
    public override void Attack(GameObject attacker, GameObject target, IHealth health, int damage)
    {
        if (health != null)
        {
            health.ReduceLife(damage);
        }
        else
        {
            Debug.LogError("Target does not have a health component");
        }
    }
}