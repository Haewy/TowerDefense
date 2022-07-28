using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private Text txtTimer;
    public float time;
    public bool gameON;
    public GameObject pauseMenu;
    public bool gameOver = false;
    public float sunCountback = 5;
    public int level = 1;
    [Header("Assign Sun")]
    public GameObject sun;
    
   

    // For victory 
    [Header("Assign Victory panel")]
    public GameObject panel_Victory;
    public bool onlyOnce;
    //For record
    public float timeForRecord;

    // Start is called before the first frame update
    void Start()
    {
        txtTimer = GetComponent<Text>();
        gameON = true;
        pauseMenu.SetActive(false);
        onlyOnce = false;
        level =SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        sunCountback -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }

        if (gameON)
        {
            Time.timeScale = 1;
            time += Time.deltaTime;
            txtTimer.text = "Time  " + time.ToString("F2");
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            //nothing
        }
        if (gameOver)
        {
            //Save the time
            timeForRecord = time;
            Time.timeScale = 0;
        }

        if(sunCountback<=0) /*(((int)time)%5==1)*/
        {
            Debug.Log("Hey a Sun");
            sunCountback = 5+level;
            PopeUpaSun();
        }
        if (time>=(110f+(level*10)) && onlyOnce)
        {
            Debug.Log("CALLING VICTORY FROM TIMER");
            gameOver = true;
            panel_Victory.SetActive(true);
            onlyOnce = false;
        }        
        if (time>=(100f + (level * 5)) && !onlyOnce && time < (100f + (level * 6)))
        {
            Debug.Log("Deactivates enemy spawner FROM TIMER");
            GameManager.instance.GetComponent<EnemySpawner>().enabled = false ;
            onlyOnce = true;
        }
    }
    public void PopeUpaSun()
    {
        Vector3 sunPosition = new Vector3(UnityEngine.Random.Range(-9.35f, 8.8f), UnityEngine.Random.Range(-5f, 3.8f), 0);
        GameObject aSun = Instantiate(sun, sunPosition, Quaternion.identity);
        //print("hey a sun");
    }

    public void Pause()
    {
        gameON = !gameON;
    }    
    public void GameOver()
    {
        gameOver = true ;
    }
    public void GoToTheMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(0);
    }
}
