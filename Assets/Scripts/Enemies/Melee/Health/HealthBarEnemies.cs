using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemies : MonoBehaviour
{
    [SerializeField] Image barImage;

    public void UpdateHealthbar(float maxHealth, float health)
    {
        barImage.fillAmount = health / maxHealth;
    }
}
