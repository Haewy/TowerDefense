using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : Tower //Attached to Attack Tower prefab
{
    [Header("Assign values")]
    public int damage;
    public float waitingInterval;
    public GameObject prefabShootItem;

    // Start is called before the first frame update
    void Start()
    {
        //Start the corotine with a delay
        StartCoroutine(ShootDelay());
    }

    IEnumerator ShootDelay() //private string
    {   //Make it wait first
        yield return new WaitForSeconds(waitingInterval);
        //Call the function to shoot the item
        Shoot();
        //Recall itself or recursion
        //ShootDelay();// this is not working, but I am not sure whynot
        StartCoroutine(ShootDelay());
    }

    private void Shoot()
    {
        //Shoot item
        GameObject shotItem = Instantiate(prefabShootItem, transform);
        //Set values of item
        shotItem.GetComponent<ShotItem>().Init(damage);
    }
    public void LoseHealth() 
    {
        health--;
        if (health <= 0)
            Die();
    }

    public void Die()
    {
        //Make a sound

        //Destroy itself
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
