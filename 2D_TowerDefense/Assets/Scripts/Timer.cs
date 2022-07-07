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
        if (Input.GetKey(KeyCode.P))
        {
            Pause();
        }

        if (gameON)
        {
            Time.timeScale = 1;
            time += Time.deltaTime;
            txtTimer.text = time.ToString("F2");
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            //nothing
        }
    }

    public void Pause()
    {
        gameON = !gameON;
    }
    public void GoToTheMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(0);
    }
}
