using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RetryTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitTheGame()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToNextLevel()
    {
        GameManager.instance.SaveDataFromVictory();
        Debug.Log("It is going to the next level...."+ SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
