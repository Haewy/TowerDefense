using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Assign values")]
    public int health =8, attack;
    public float speed =1, intervalDying =1 , intervalColor = 0.1f;

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

    // Update is called once per frame
    void Update()
    {
        Move() ;

    }
}
