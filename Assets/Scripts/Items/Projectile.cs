using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10;
    public enum FlagAttack
    {
        Player,
        Enemies
    }
    public FlagAttack currentFlag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&currentFlag == FlagAttack.Enemies)
        {
            Health health = other.GetComponent<Health>();
            health.ReduceLife(damage);
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemies")&&currentFlag == FlagAttack.Player)
        {
            Health health = other.GetComponent<Health>();
            health.ReduceLife(damage);
            Destroy(gameObject);
        }
        if (other.CompareTag("Destructible"))
        {
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
