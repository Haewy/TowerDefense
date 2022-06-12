using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    // Enemy Prefabs
    public List<GameObject> prefabs;
    // Spawn point
    public List<Transform> spawnPoints;
    // Interval
    public float spawnInterval = 2f;

    private void Awake()
    {
        instance = this;
    }

    // To be called once the game starts
    public void StartSpawning()
    {
        StartCoroutine(SpawnDelay());
    }

    // To be looping
    IEnumerator SpawnDelay()
    {
        // Spawn
        SpawnEnemy();
        // Wait
        yield return new WaitForSeconds(spawnInterval);
        // Repeat
        StartCoroutine(SpawnDelay());
    }

    private void SpawnEnemy()
    {
        int randomID = UnityEngine.Random.Range(0, prefabs.Count);
        int randomSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Count);

        GameObject spawnedEnemy = Instantiate(prefabs[randomID], spawnPoints[randomSpawnPoint]);
    }
}
