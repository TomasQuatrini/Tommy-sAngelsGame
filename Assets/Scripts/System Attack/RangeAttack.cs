using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that implements the ranged attack state
public class RangedAttack : AttackState
{
    // Method that is called when a ranged attack is performed
    public override void Attack(GameObject attacker, GameObject target, Health health, int damage)
    {
        // Logic to perform a ranged attack
        Debug.Log("Ranged attack performed");
    }
}
