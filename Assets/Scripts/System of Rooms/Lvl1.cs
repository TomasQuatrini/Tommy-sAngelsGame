using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1 : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private Room level1;
    private bool _initTiming = false;
    private bool _keyWasSpawned = false;

    void Start()
    {
        level1 = new Room("Level 1");
    }

    void Update()
    {
        // Si ya no hay enemigos, spawnea la llave (una sola vez)
        if (!_keyWasSpawned && !HaveEnemies)
        {
            if (key != null)
            {
                key.GetComponent<KeyManager>().SpawnKey();
                _keyWasSpawned = true;
            }
        }

        // Si la llave fue destruida, iniciar temporizador
        if (_keyWasSpawned && key == null && !_initTiming)
        {
            //InitT();
        }

        // Tick del temporizador
        if (_initTiming)
        {
            level1.Tick(Time.deltaTime);
        }
    }

    private bool HaveEnemies
    {
        get
        {
            foreach (Transform child in transform)
            {
                if (child.name.StartsWith("EnemyMelee"))
                    return true;
            }
            return false;
        }
    }

    private void InitT()
    {
        Debug.Log("InitT() was called");
        _initTiming = true;
        level1.InitTimer(30);
    }
}