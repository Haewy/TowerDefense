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
    public Timer timer;

    private void Awake()
    {
        instance = this;
        spawner = GetComponent<Test_Spawner>();
        health = GetComponent<HealthSystem>();
        currency = GetComponent<CurrencySystem>();
        score = GetComponent<Score>();
        timer = GameObject.Find("UI/TextTimer").GetComponent<Timer>();
        gamer = GameObject.Find("Gamer").GetComponent<Gamer>();

    }

    private void Start()
    {
        //if (gamer == null)
        //{
        //    gamer = gameObject.AddComponent<Gamer>();
        //}
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

    public void SaveDataFromGamerOnPause() //gamer script has the function to save the statistics
    {
        this.gamer.SaveLevel(gamer.currentLevel, this.score.currentScore, this.timer.time, false);
    }
    public void SaveDataFromVictory()
    {
        this.gamer.SaveLevel(gamer.currentLevel, this.score.currentScore, this.timer.time, true);
    }
        
}
