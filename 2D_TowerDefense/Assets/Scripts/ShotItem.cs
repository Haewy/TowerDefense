using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotItem : MonoBehaviour
{
    public Transform graphic;

    [Header ("Assign values")]
    public int damage;
    public float speedFlying, speedRotating;
    // Start is called before the first frame update
    void Start()
    {
        //  graphic = GetComponentInChildren<Transform>();    
    }

    public void Init(int dmg)
    { damage = dmg; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("HIT");
            Destroy(gameObject);
        }        
        if (collision.tag == "Out")
        {
            Debug.Log("Out of zone");
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        FlyForward();
        Rotate();
       
    }

    private void Rotate()
    {
        graphic.Rotate(new Vector3(0, 0, -speedRotating * Time.deltaTime));
    }

    private void FlyForward()
    {
        transform.Translate(transform.right * speedFlying * Time.deltaTime);
    }
}
