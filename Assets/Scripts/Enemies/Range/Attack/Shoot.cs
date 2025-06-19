using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float fireCooldown    = 0.5f;
    public float projectileSpeed = 5f;
    private float lastFireTime;
    public void Attack(Transform player)
    {
        if (Time.time < lastFireTime + fireCooldown)
            return;

        lastFireTime = Time.time;

        // Direction toward player
        Vector2 dir = (player.position - shootPoint.position).normalized;

        // Instantiate and launch projectile
        GameObject proj = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        Projectile projScript = proj.GetComponent<Projectile>();
        if (projScript != null)
        {
            projScript.currentFlag = Projectile.FlagAttack.Enemies;
        }
        Rigidbody2D rb   = proj.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = dir * projectileSpeed;
    }
}
