using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemies : MonoBehaviour
{
    [SerializeField]private Image barImage;
    private Health _health;

    private float _fillAmount;

    void Start()
    {
        if (barImage == null)
        {
            Debug.LogError("No se encuentra Image");
        }
        _health = GetComponentInParent<Health>();
        if (_health == null)
        {
            Debug.LogError("No se encuentra Health");
        }
    }
    
    void Update()
    {
        _fillAmount = _health.GetFillAmount();
        barImage.fillAmount = _fillAmount;
    }
}
