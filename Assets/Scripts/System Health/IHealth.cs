using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
    {
        void ReduceLife(int amount);
        void IncreaseLife(int amount);
        int CurrentHealth { get; }
        int MaxHealth { get; }
    }
