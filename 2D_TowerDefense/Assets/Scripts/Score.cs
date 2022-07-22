using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour// Attached to GameManager in order to work as singleton
{
    public Text txtScore;
    public float currentScore;

    // For victory 
    [Header("Assign Victory panel")]
    public GameObject panel_Victory;


    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = "Score " + currentScore.ToString();
        // Trigger the victory 
        if (currentScore == 50.0f)
        {
            Debug.Log("You reach the score for next level");
            panel_Victory.SetActive(true);
        }

    }

    public void AddPoints(int points) 
    {
        currentScore += points;

    }
}
