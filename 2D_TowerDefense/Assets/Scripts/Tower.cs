using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tower: MonoBehaviour
{

    //Health
    public int health;//it goes to its mother class: Tower
    //Cost value
    public int cost;//it goes to its mother class: Tower


    // Lose health and die
    public bool LoseHealth(int damage)
    {
        health--;
        if (health == 0)
        {

            Die();
            return true;
        }
        return false;
    }
    public void Die()
    {

        Debug.Log("Tower is dead");
        Destroy(gameObject);



    }

}