using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour// Attached to GameManager in order to work as singleton
{
    public Text txtScore;
    public float currentScore;
    public bool onlyOnce;

    // For victory 
    [Header("Assign Victory panel")]
    public GameObject panel_Victory;


    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        onlyOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = "Score " + currentScore.ToString();
        // Trigger the victory 
        if (currentScore >= 1000.0f && !onlyOnce)
        {
            onlyOnce = true;
            Debug.Log("You reach the score for next level");
            panel_Victory.SetActive(true);
            //Freeze the game
            //From Timer script switch the bool GameOver to true using GameManager to get Timer script
            GameManager.instance.timer.gameOver = true;
            //Save data for this level using GamerManager to get Gamer and save data
            GameManager.instance.SaveDataFromVictory();
        }

    }

    public void AddPoints(int points) 
    {
        currentScore += points;

    }
}
