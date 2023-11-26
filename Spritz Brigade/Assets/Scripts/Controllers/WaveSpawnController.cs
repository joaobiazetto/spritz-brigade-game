using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnController : MonoBehaviour
{
    public Transform[] spawnPoints;

    public void SpawnWave(EnemyWave wave)
    {
        Debug.Log($"Spawning Wave {wave.waveName}...");

        StartCoroutine(SpawnEnemies(wave));
    }

    private IEnumerator SpawnEnemies(EnemyWave wave)
    {
        Debug.Log($"Enemies to spawn: {wave.enemyCount}");

        for (int i = 0; i < wave.enemyCount; i++)
        {
            Debug.Log("Spawning Enemies!");

            Transform spawnPoint = spawnPoints[i % spawnPoints.Length];
            Vector3 spawnPosition = spawnPoint.position;

            EnemyManager.Instance.SpawnEnemy(spawnPosition, wave.enemyPrefab);

            yield return new WaitForSeconds(1f / wave.spawnRate);
        }

        yield break;
    }
}
