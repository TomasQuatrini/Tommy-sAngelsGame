using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedShootArm : MonoBehaviour
{
    private Collider2D _collider;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var PlayerAttack = other.GetComponent<PlayerAttack>();
            if (PlayerAttack == null)
            {
                Debug.LogError("No se encuentra componente player attack");
            }
            PlayerAttack.ShootLocked = false;
            Destroy(gameObject);
        }
    }
}
