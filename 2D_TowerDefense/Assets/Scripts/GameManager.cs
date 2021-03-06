using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    public Test_Spawner spawner;
    public HealthSystem health;
    public CurrencySystem currency;
    public Score score;
    public Gamer gamer;

    private void Awake()
    {
        instance = this;
        spawner = GetComponent<Test_Spawner>();
        health = GetComponent<HealthSystem>();
        currency = GetComponent<CurrencySystem>();
        score = GetComponent<Score>();
        gamer = GameObject.Find("Gamer").GetComponent<Gamer>();
    }

    private void Start()
    {
        GetComponent<CurrencySystem>().Init();
        GetComponent<HealthSystem>().Init();

        StartCoroutine(WaveStartDelay());
    }
    IEnumerator WaveStartDelay()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<EnemySpawner>().StartSpawning();
    }
    public void SetGamer(Gamer gamer)
    {
        this.gamer = gamer;
    }
        
}
