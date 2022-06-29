using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTower : Tower
{
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //animator.Play("Hit");
            animator.SetTrigger("Hit");
            Debug.Log("HIT HIT HIT HIT");
            float interval = collision.GetComponent<Enemy>().attackIterval;
            StartCoroutine(IntervalAttack(interval));
        }
    }

    IEnumerator IntervalAttack(float interval)
    {
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(interval);
        Debug.Log("It is working");
        StartCoroutine(IntervalAttack(interval));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Heeeeeeeeeeeeeey");
        }
    }    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //animator.Play("Hit");
            Debug.Log("OH NO! Tower DEAD");
        }
    }

    //public void LoseHealth()
    //{
    //    health--;
    //    if (health <= 0)
    //    {
    //        Die();
    //    }
    //}

    //private void Die()
    //{
    //    Debug.Log("Defense Tower is Dead");
    //    Destroy(gameObject);
    //}
}
