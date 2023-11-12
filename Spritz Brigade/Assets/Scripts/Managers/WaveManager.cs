using System;
using System.Collections;
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

                if (!HasDefeatedAllEnemies())
                {

                } 
                else
                {
                    return;
                }
            }
        }

        if (waveCountdown <= 0 && state != SpawnStateEnum.SPAWNING)
        {
            StartCoroutine(SpawnWave(enemyWaves[_nextWave]));
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

    IEnumerator SpawnWave(EnemyWave wave)
    {
        state = SpawnStateEnum.SPAWNING;

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemies(wave.enemyPrefab);

            //yield return WaitForSeconds(1f / wave.spawnRate);
        }

        state = SpawnStateEnum.WAITING;

        yield break;
    }

    private void SpawnEnemies(AssetReference assetReference)
    {
        throw new NotImplementedException();
    }
}
