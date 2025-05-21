using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2 : MonoBehaviour
{
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
        if (HaveEnemies)
        {
            return;
        }
        else
        {
            Transform key = transform.Find("Key");
            if (key != null)
            {
                key.gameObject.SetActive(true);
            }
            else
            {
                return;
            }
        }
    }
}