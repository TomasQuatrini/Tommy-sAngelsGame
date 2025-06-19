using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    private Health _health;

    void Start()
    {
        _health = GetComponent<Health>();
    }

    void Update()
    {
        if (_health.CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
