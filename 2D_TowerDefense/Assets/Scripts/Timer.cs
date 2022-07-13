using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private Text txtTimer;
    public float time;
    public bool gameON;
    public GameObject pauseMenu;
    public bool gameOver = false;
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
            Time.timeScale = 0;
        }
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
