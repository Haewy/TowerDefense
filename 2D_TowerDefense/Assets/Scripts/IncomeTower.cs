using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeTower : Tower
{   // Attach to Prefab of Income tower
    // Properties
    [Header("Assign value for this character")]
    //Health
    //public int health;//it goes to its mother class: Tower
    //Cost value
    //public int cost;//it goes to its mother class: Tower
    //Income value that add to the player 
    public int incomeValue;
    //Interval for income
    public float interval;
    public int appearingTime;

    [Header("Assign image for coin")]
    public GameObject coinImg;
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
        StartCoroutine(ShowCoin());
    }

    IEnumerator ShowCoin()
    {
        AudioManager.i.Play(AudioManager.Sound.nine);
        coinImg.SetActive(true);
        // The waiting
        yield return new WaitForSeconds(appearingTime);
        coinImg.SetActive(false);
    }

    void Start()
    {
        coinImg = this.gameObject.transform.GetChild(0).gameObject;
        Init();
    }
    //// Lose health and die
    //public void LoseHealth()
    //{
    //    health--;
    //    if (health<=0)
    //    {
    //        Die();
    //    }
    //}
    //public void Die() 
    //{
    //    Debug.Log("Tower is dead");
    //    Destroy(gameObject);
    //}
}
