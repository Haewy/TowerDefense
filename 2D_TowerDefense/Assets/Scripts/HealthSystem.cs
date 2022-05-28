using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [Header("Assign Health Text")]
    public Text txt_Health;
    [Header("Assign Game over panel")]
    public GameObject panel_GameOver;
    [Header("Assign a default|initial value")]
    public int defaultHealth;
    // Current(real time) health value
    public int health;

    // Set the default values
    public void Init()
    {
        //panel_GameOver.SetActive(false);
        health = defaultHealth;
        UpdateHealthUI();
    }

    // Discount health and Check if the game is over
    public void ReceiveDamage(int val)
    {   
        // Check if the current health is available to be reduced
        if (health>=1)
        {
            health -= val;
            UpdateHealthUI();
        }
        // Check if the current health leads to Game Over  
        if (health<=0) 
        {
            panel_GameOver.SetActive(true);
            // Code for freeze the game?
        }
    }

    // Update health
    private void UpdateHealthUI()
    {
        txt_Health.text = health.ToString();
    }

    // MAYBE Recover Health 
    //public void Recover(int val)
    //{
    //    health += val;
    //    UpdateHealthUI();
    //}
}
