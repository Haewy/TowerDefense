using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyItself", 2f);
        //CircleCollider2D aColider = gameObject.AddComponent<CircleCollider2D>();
        gameObject.transform.SetParent(GameObject.Find("UI").transform);
    }

    public void DestroyItself()
    {
        Destroy(gameObject);
    }
    public void AddSun()
    {
        GameManager.instance.score.AddPoints(5);
        GameManager.instance.currency.Gain(5);
        DestroyItself();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.001f, 0.001f, 0));    
    }
    //private void OnMouseEnter()
    //{
    //    Vector3 sc = transform.localScale;
    //    sc*= 1.2f; 
    //}
}
