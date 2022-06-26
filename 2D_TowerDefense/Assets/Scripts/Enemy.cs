using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Assign values")]
    public int health =8, attack;
    public float speed =1, intervalDying =1 , intervalColor = 0.1f;

    public Animator anim;
    public float attackIterval;
    private Coroutine attackOrder;
    private Tower detectedTower;

    void Move() 
    {
       
        transform.Translate(-transform.right * speed * Time.deltaTime);
    }

    public void LoseHealth()
    {   // Decrease health
        health--;

        // Make a noise for being hit                        // JUST TESTING 
        AudioManager.i.Play(AudioManager.Sound.three);
        // Blink in red
        StartCoroutine(Blink());
        // Check if it still is alive
        if (health<=0)
        {
            
            StartCoroutine(Die());
        }
    }

    IEnumerator Blink()
    {// Chance color
        GetComponent<SpriteRenderer>().color = Color.red;
        // Wait a moment with changed color
        yield return new WaitForSeconds(intervalColor);
        // Bring back the original color
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator Die()
    {
        // Make a noise for die                         // JUST TESTING 
         AudioManager.i.Play(AudioManager.Sound.two);
        // Waiting for the sound being played               JUST TESTING 
        yield return new WaitForSeconds(intervalDying);
        // destroy then
        Destroy(gameObject);
    }

    IEnumerator Attack()
    {
        anim.Play("Attacking",0,0);
        yield return new WaitForSeconds(attackIterval);
        // Store the Coroutine to hold a moment until getting a response that a tower is dead
        // If the Coroutine is not held, Attack will keep running
        attackOrder = StartCoroutine(Attack());

    }
    public void Damage()
    {
        bool towerDied = detectedTower.LoseHealth(attack);

        // Line 69 
        // It says that NullReferenceException: Object ref not set to an instance of an obj....
        // It only happens when Chicken makes towers died. 
  
        if (towerDied)
        {
            //Activate the animator's value in order to go back to the Move animation
            anim.SetBool("TowerIsDead", true);
            anim.SetBool("DetectedTower", false);

            detectedTower = null;
            StopCoroutine(attackOrder);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (!detectedTower)
        {
            Move();
        }
        

    }
    // Detect Towers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (detectedTower)
        {
            return; 
        }
        if (collision.tag == "Tower")
        {
            // Alert 
            Debug.Log("Detect you ! Tower !");
            anim.SetBool("DetectedTower", true);
          
            Debug.Log("DT value" + anim.GetBool("DetectedTower"));
            detectedTower = collision.GetComponent<Tower>();
            // Store the Coroutine to hold a moment until getting a response that a tower is dead
            // If the Coroutine is not held, Attack will keep running
            attackOrder = StartCoroutine(Attack());
        }
    }


}
