using UnityEngine;

/// <summary>
/// Handles ranged attack: instantiates projectiles toward the player with a cooldown.
/// </summary>
public class EnemyRangeAttack : MonoBehaviour
{
    public GameObject _shootArm;
    private Shoot _shoot;

    void Start()
    {
        _shoot = GetComponentInChildren<Shoot>();
        if (_shoot == null)
        {
            Debug.LogError("No se encuentra Shoot");
        }
        _shootArm.SetActive(false);
    }
    public void Attacking(Transform player)
    {
        _shootArm.SetActive(true);
        _shoot.Attack(player);
    }

    public void NotAttacking()
    {
        _shootArm.SetActive(false);
    }
}