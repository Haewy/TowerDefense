using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeTower : MonoBehaviour
{
    // Properties
    [Header("Assign value for this character")]
    //Health
    public int health;
    //Cost value
    public int cost;
    //Income value that add to the player 
    public int incomeValue;
    //Interval for income
    public float interval;

    // Methods
    public void Init()
    {
        StartCoroutine(Interval());
    }

    IEnumerator Interval()
    {   // The waiting
        yield return new WaitForSeconds(interval);
        // The action of increasing income
        IncreaseIncome();
        // Repeat in a loop by selfcalling
        Init();
    }

    public void IncreaseIncome()
    {
        GameManager.instance.currency.Gain(incomeValue);
    }

    void Start()
    {
        Init();
    }

}
