using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTower : Tower
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoseHealth()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Defense Tower is Dead");
        Destroy(gameObject);
    }
}
