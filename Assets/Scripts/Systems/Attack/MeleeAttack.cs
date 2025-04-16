using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that implements the melee attack state
public class MeleeAttack : AttackState
{
    // Method that is called when a melee attack is performed
    public override void Attack(PlayerAttack playerAttack)
    {
        // Logic to perform a melee attack
        Debug.Log("Melee attack performed");
    }
}