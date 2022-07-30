using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        GetComponent<Image>().enabled = false;
        Debug.Log("ErasedNOW!");
        Destroy(gameObject,1f);
    }
    public void AddSun()
    {
        AudioManager.i.Play(AudioManager.Sound.nine);
        GameManager.instance.score.AddPoints(5);
        GameManager.instance.currency.Gain(5);
        DestroyItself();
    }
    public void OnShinyParticle()
    {
        GameManager.instance.score.shinyParticle.SetActive(true);
        Invoke("DeShinyParticle", 0.8f);
    }
    public void DeShinyParticle()
    {
        GameManager.instance.score.shinyParticle.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.001f, 0.001f, 0));    
    }
    private void OnMouseEnter()
    {
        Vector3 sc = transform.localScale;
        sc *= 1.2f;
    }
}
