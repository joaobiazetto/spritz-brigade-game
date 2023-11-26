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

    private WaveSpawnController _waveSpawnController;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        _waveSpawnController = GetComponent<WaveSpawnController>();
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
                state = SpawnStateEnum.SPAWNING;

                _waveSpawnController.SpawnWave(enemyWaves[_nextWave]);

                state = SpawnStateEnum.WAITING;
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
}
