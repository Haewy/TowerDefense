using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour// Attached to GameManager in order to work as singleton
{
    public Text txtScore;
    public float currentScore;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = currentScore.ToString();
    }

    public void AddPoints(int points) 
    {
        currentScore += points;
    }
}
