using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Variable that stores the current attack state
    private AttackState currentAttackState;

    // Method that sets the current attack state
    public void SetAttack(AttackState state)
    {
        // Assigns the current attack state
        currentAttackState = state;
    }

    // Method that performs an attack
    public void Attack()
    {
        // Calls the attack method of the current state
        currentAttackState.Attack(this);
    }
}
