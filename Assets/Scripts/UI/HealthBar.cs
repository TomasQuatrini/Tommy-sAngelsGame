using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    
    public void ChangeMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void ChangeCurrentHealth(float currentHealth)
    {
        slider.value = currentHealth;
    }
    
    public void InitializeHealthBar(float currentHealth)
    {
        ChangeMaxHealth(currentHealth);
        ChangeCurrentHealth(currentHealth);
    }
}

