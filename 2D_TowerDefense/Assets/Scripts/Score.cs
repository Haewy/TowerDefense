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

    public GameObject scoreTemp;
    public Text txtTemp;
    public Color aColor;

    // Particle 
    public GameObject shinyParticle;
    private void Awake()
    {
        shinyParticle.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        onlyOnce = false;
        scoreTemp = GameObject.Find("/UI/TextScoreTemp");
        txtTemp = scoreTemp.GetComponent<Text>();
        txtTemp.enabled = false;
        aColor = txtTemp.color;
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = "Score " + currentScore.ToString();
        // Trigger the victory 
        if (currentScore >= 1500.0f && !onlyOnce)
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
        txtTemp.enabled = true;
        txtTemp.color = aColor;
        txtTemp.text = "+" + points.ToString();
        Invoke("DisableText", 1f);
        currentScore += points;
    }    
    public void LosePoints(int points) 
    {
        txtTemp.enabled = true;
        txtTemp.color = Color.red;
        txtTemp.text = "-" + points.ToString();
        Invoke("DisableText", 1f);
        currentScore -= points;
    }
    public void DisableText() 
    {
        txtTemp.enabled = false;
    }
}
