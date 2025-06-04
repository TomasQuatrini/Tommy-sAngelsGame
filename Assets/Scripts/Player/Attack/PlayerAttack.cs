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
        meleeAttack = new MeleeAttack();
        meleeHitbox.GetComponent<Collider2D>().enabled = false;
        meleeHitbox.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Perform an attack on a target.
    public void Attack(GameObject target)
    {
        EnemyMeleeHealth enemyHealth = target.GetComponent<EnemyMeleeHealth>();
        if (enemyHealth == null)
        {
            Debug.LogError("Target does not have an EnemyMeleeHealth component");
            return;
        }

        if (enemyHealth.GetHealth() == null)
        {
            Debug.LogError("Target does not have a health component");
            return;
        }

        if (meleeAttack == null)
        {
            Debug.LogError("MeleeAttack is not assigned");
            return ;
        }

        meleeAttack.Attack(gameObject, target, enemyHealth.GetHealth(), damageMelee);
    }

    // Handle player input.
    private void HandleInput()
    {
        // Check if the K key is pressed.
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            meleeHitbox.GetComponent<Collider2D>().enabled = true;
            meleeHitbox.GetComponent<SpriteRenderer>().enabled = true;
            // Activate the melee hitbox.
            // You can add an attack effect here, such as an animation or sound.
            // Deactivate the melee hitbox after a short period of time.
            Invoke(nameof(DisableHitbox), 0.2f); // 0.2 seconds
        }
    }

    // Disable the hitbox collider.
    private void DisableHitbox()
    {
        meleeHitbox.GetComponent<Collider2D>().enabled = false;
        meleeHitbox.GetComponent<SpriteRenderer>().enabled = false;
    }    

    // Update is called once per frame.
    private void Update()
    {
        HandleInput();
    }
}