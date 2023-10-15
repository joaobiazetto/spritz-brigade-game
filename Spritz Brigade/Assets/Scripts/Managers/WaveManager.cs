using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform sandCastleTransform;
    [SerializeField] private float timeBetweenWaves = 5f;

    private int currentWave = 0;

    private void Start()
    {
        // Start the wave spawning coroutine
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true) // Infinite loop for continuous waves
        {
            currentWave++;

            Debug.Log($"Starting Wave {currentWave}");

            // Spawn enemies for the current wave
            SpawnEnemiesForWave();

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private void SpawnEnemiesForWave()
    {
        // Example: Wave 1 has 2 toddlers and 1 preSchooler
        int toddlersToSpawn = currentWave * 2;
        int preSchoolersToSpawn = currentWave;

        // Randomly select spawn points
        Transform[] selectedSpawnPoints = GetRandomSpawnPoints(spawnPoints, toddlersToSpawn + preSchoolersToSpawn);

        // Spawn toddlers
        for (int i = 0; i < toddlersToSpawn; i++)
        {
            enemyManager.SpawnToddler(selectedSpawnPoints[i].position, GetRandomTarget());
        }

        // Spawn preSchoolers
        for (int i = toddlersToSpawn; i < toddlersToSpawn + preSchoolersToSpawn; i++)
        {
            enemyManager.SpawnPreSchooler(selectedSpawnPoints[i].position, GetRandomTarget());
        }
    }

    private Transform GetRandomTarget()
    {
        // Example: Get a random player or sand castle transform as the target
        return Random.Range(0f, 1f) > 0.5f ? playerTransform : sandCastleTransform;
    }

    private Transform[] GetRandomSpawnPoints(Transform[] spawnPoints, int count)
    {
        // Shuffle the spawn points array and return the first 'count' elements
        for (int i = spawnPoints.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (spawnPoints[randomIndex], spawnPoints[i]) = (spawnPoints[i], spawnPoints[randomIndex]);
        }

        return spawnPoints.Take(count).ToArray();
    }
}
