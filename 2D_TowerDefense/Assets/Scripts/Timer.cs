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

    //For record
    public float timeForRecord;

    // Start is called before the first frame update
    void Start()
    {
        txtTimer = GetComponent<Text>();
        gameON = true;
        pauseMenu.SetActive(false);
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
            sunCountback = 5*level;
            PopeUpaSun();
        }
    }
    public void PopeUpaSun()
    {
        Vector3 sunPosition = new Vector3(UnityEngine.Random.Range(0, 6f), UnityEngine.Random.Range(0, 6f), 0);
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
