using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeHealth : MonoBehaviour
{
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
    }
    void Update()
    {
        if (_health.CurrentHealth == 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
