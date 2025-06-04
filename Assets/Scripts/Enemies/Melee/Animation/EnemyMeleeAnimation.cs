using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyMeleeAnimation : MonoBehaviour
{
    private Animator _animator;
    private EnemyMeleeMovement _movement;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<EnemyMeleeMovement>();
    }

    void Update()
    {
        Vector2 velocity = _movement.GetVelocity();

        if (velocity.magnitude < 0.05f)
        {
            // Podés agregar una animación de Idle si tenés
            return;
        }

        // Elegimos animación según dirección
        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
        {
            _animator.Play("WalkR-LCapi");
        }
        else if (velocity.y > 0)
        {
            _animator.Play("WalkBackCapi");
        }
        else
        {
            _animator.Play("WalkFrontCapi");
        }
    }
}