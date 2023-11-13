using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class WaveManager : MonoBehaviour
{
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public EnemyWave[] enemyWaves;

    private SpawnStateEnum state = SpawnStateEnum.COUNTING;

    private int _nextWave = 0;

    private float searchCountdowm = 1f;

    public Transform[] spawnPoints;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (state == SpawnStateEnum.WAITING)
        {
            searchCountdowm -= Time.deltaTime;

            if (searchCountdowm <= 0f )
            {
                searchCountdowm = 1f;

                if (HasDefeatedAllEnemies())
                {
                    OnWaveCompleted();
                } 
                else
                {
                    return;
                }
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnStateEnum.SPAWNING && state != SpawnStateEnum.WAITING)
            {
                SpawnWave(enemyWaves[_nextWave]);
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    private bool HasDefeatedAllEnemies()
    {
        return GameObject.FindGameObjectWithTag("Enemy") == null;
    }

    private void OnWaveCompleted()
    {
        state = SpawnStateEnum.COUNTING;

        waveCountdown = timeBetweenWaves;

        if (_nextWave + 1 > enemyWaves.Length - 1)
        {
            _nextWave = 0;

            Debug.Log("ALL WAVES COMPLETED! Looping...");
        }

        _nextWave++;
    }

    private void SpawnWave(EnemyWave wave)
    {
        Debug.Log($"Spawning Wave {wave.waveName}...");

        state = SpawnStateEnum.SPAWNING;

        StartCoroutine(SpawnEnemies(enemyWaves[_nextWave])); ;

        state = SpawnStateEnum.WAITING;
    }

    IEnumerator SpawnEnemies(EnemyWave wave)
    {
        //int enemiesToSpawn = Mathf.Min(enemyWaves[_nextWave].enemyCount, spawnPoints.Length);

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
