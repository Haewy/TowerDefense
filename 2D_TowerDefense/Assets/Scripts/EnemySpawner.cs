using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    // Enemy Prefabs
    public List<GameObject> prefabs;
    // Spawn point
    public List<Transform> spawnPoints;
    // Interval
    private float spawnInterval = 3.3f;
    //how many type of enemies are going to be spawned
    public int levelSpawner;

    public Text dangerText;
    private void Awake()
    {
        instance = this;
    }

    // To be called once the game starts
    public void StartSpawning()
    {
        dangerText = GameObject.Find("/UI/Towers/DangerText").GetComponent<Text>();
        dangerText.text = "Watch Out! Enemies are Coming!";
        dangerText.gameObject.SetActive(false);
        //dangerText.enabled = false;
        Debug.Log("level" + SceneManager.GetActiveScene().buildIndex);
        levelSpawner = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.GetActiveScene().buildIndex>=2)
        {
            spawnInterval = 2.2f;
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 4)
        {
            spawnInterval = 1.7f;
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 6)
        {
            spawnInterval = 1.5f;
        }
        StartCoroutine(SpawnDelay());
    }

    // To be looping
    IEnumerator SpawnDelay()
    {
        //dangerText.gameObject.SetActive(false);
        if (GameManager.instance.timer.time>70)
        {
            
            dangerText.text = "Watch Out! There are more Coming!";
            dangerText.gameObject.SetActive(true);
            Invoke("disableText", 3f);
            spawnInterval = 1.3f;
            Debug.Log("Start spawning more frequently from now on");
        }
        // Spawn
        SpawnEnemy();
        // Wait
        yield return new WaitForSeconds(spawnInterval);
        // Repeat
        StartCoroutine(SpawnDelay());
    }
    public void disableText()
    { dangerText.enabled = false; }
    private void SpawnEnemy()
    {
        if (GameManager.instance.timer.gameOver == false)
        {
            int randomID = UnityEngine.Random.Range(0, levelSpawner);
            int randomSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Count);
            Debug.Log("spawningenemy");
            GameObject spawnedEnemy = Instantiate(prefabs[randomID], spawnPoints[randomSpawnPoint]);
        }

    }
}
