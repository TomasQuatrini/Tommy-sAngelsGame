using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that implements the melee attack state
public class MeleeAttack : AttackState
{
    public override void Attack(GameObject attacker, GameObject target, Health health, int damage)
    {
        health.ReduceLife(damage);
    }
}