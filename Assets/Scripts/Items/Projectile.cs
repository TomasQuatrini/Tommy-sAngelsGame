using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            Health health = other.GetComponent<Health>();
            health.ReduceLife(damage);
            Destroy(gameObject);
        }
        if (other.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
