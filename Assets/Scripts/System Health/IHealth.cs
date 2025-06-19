using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
    {
        void ReduceLife(float amount);
        void IncreaseLife(float amount);
        float CurrentHealth { get; }
        float MaxHealth { get; }
    }
