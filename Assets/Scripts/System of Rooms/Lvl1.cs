using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1 : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject key;
    [SerializeField] public bool hasTimer = false;

    Room level1 = new Room("Level 1");


    bool HaveEnemies
    {
        get
        {
            foreach (Transform child in transform)
            {
                if (child.name.StartsWith("EnemyMelee"))
                {
                    return true;
                }
            }
            return false;
        }
    }

    void Update()
    {     
        if (!HaveEnemies)
        {
            if(key == null) return;

            key.GetComponent<KeyManager>().SpawnKey();    

            level1.InitTimer(30);                      
        }
        if (level1.IsTimerRunning)
        {
            level1.Tick(Time.deltaTime);
        }
        if (hasTimer is true)
        {
            level1.hasTimer = true;
        }
    }
    public void InitT()
    {
        if (level1.hasTimer is true)
        {
            level1.InitTimer(30);
        }
        else
        {
            Debug.Log("The Room have not timer");
        }
    }
}