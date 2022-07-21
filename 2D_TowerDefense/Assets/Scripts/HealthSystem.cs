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
    [Header("Assign timer")]
    public Timer timer;
    [Header("Assign Explosion and black spot")]
    public GameObject sExplosion;
    public GameObject blackSpot;
    // Current(real time) health value
    public int health;
    //public Collider2D protectedZone;

    // Set the default values
    public void Init()
    {
        //protectedZone = GameObject.Find("ProtectedZone ").GetComponent<Collider2D>();
        timer = FindObjectOfType<Timer>();
        panel_GameOver.SetActive(false);
        health = defaultHealth;
        UpdateHealthUI();
    }

    // Discount health and Check if the game is over
    public void ReceiveDamage(Vector3 aVector)
    {   
        // Check if the current health is available to be reduced
        if (health>=1)
        {
            //if (Time.timeScale ==0)
            //{
            //    Time.timeScale = 1;
            //}
            health -= 1;
            Instantiate(sExplosion, aVector, Quaternion.identity);
            Instantiate(blackSpot, aVector, Quaternion.identity);
            // Make a noise for achieve explosing                       // JUST TESTING 
            AudioManager.i.Play(AudioManager.Sound.seven);

            UpdateHealthUI();
        }
        // Check if the current health leads to Game Over  
        if (health<=0) 
        {
            AudioManager.i.Play(AudioManager.Sound.five);

            panel_GameOver.SetActive(true);
            // Code for freeze the game?
            //Time.timeScale = 0;//not working because it is not called in update
            timer.GameOver();//timer stops
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

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag=="Enemy")
    //    {
    //        Debug.Log("DAMAGE DONE IN PROTECTED ZONE");
    //        ReceiveDamage(1);
    //    }
    //}
}
