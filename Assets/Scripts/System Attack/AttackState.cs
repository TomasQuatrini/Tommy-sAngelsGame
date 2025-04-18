using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for attack states
public abstract class AttackState
{
    // Abstract method that is called when an attack is performed
    public abstract void Attack(PlayerAttack playerAttack);
}
