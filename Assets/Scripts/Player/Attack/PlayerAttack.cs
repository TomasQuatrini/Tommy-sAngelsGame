using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player attacks.
public class PlayerAttack : MonoBehaviour
{
    // The melee hitbox game object.
    public GameObject meleeHitbox;
    // The melee attack script.
    public MeleeAttack meleeAttack;
    // The ranged attack script.
    public RangedAttack rangedAttack;

    [SerializeField] int damageMelee = 10;
    

    private void Start()
    {
        meleeHitbox.SetActive(false);
        meleeAttack = new MeleeAttack();
    }

    // Perform an attack on a target.
    public void Attack(GameObject target)
    {
        EnemyMeleeHealth enemyHealth = target.GetComponent<EnemyMeleeHealth>();
        if (enemyHealth == null)
        {
            Debug.LogError("El objetivo no tiene un componente EnemyMeleeHealth");
            return;
        }

        if (enemyHealth.GetHealth() == null)
        {
            Debug.LogError("El objetivo no tiene un componente de salud");
            return;
        }

        if (meleeAttack == null)
        {
            Debug.LogError("MeleeAttack no está asignado");
            return ;
        }

        meleeAttack.Attack(gameObject, target, enemyHealth.GetHealth(), damageMelee);
    }

    // Handle player input.
    private void HandleInput()
    {
        // Check if the K key is pressed.
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Activate the melee hitbox.
            meleeHitbox.SetActive(true);

            // You can add an attack effect here, such as an animation or sound.
            // ...

            // Deactivate the melee hitbox after a short period of time.
            Invoke(nameof(DesactivarHitbox), 0.2f); // 0.2 seconds
        }
    }

    // Deactivate the melee hitbox.
    private void DesactivarHitbox()
    {
        meleeHitbox.SetActive(false);
    }

    // Update is called once per frame.
    private void Update()
    {
        HandleInput();
    }
}