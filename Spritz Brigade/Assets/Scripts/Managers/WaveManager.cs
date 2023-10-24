using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private GameObject playerRig;
    [SerializeField] private GameObject sandCastleRig;
    [SerializeField] private float timeBetweenWaves = 5f;

    private int currentWave = 0;

    private static WaveManager _instance;

    public static WaveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindWithTag("WaveManager")?.GetComponent<WaveManager>();

                if (_instance == null)
                {
                    GameObject managerObject = new GameObject("WaveManager");
                    managerObject.tag = "EnemyManager";
                    _instance = managerObject.AddComponent<WaveManager>();
                }
            }
            return _instance;
        }
    }

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

        // Convert the array to a list for shuffling
        List<Transform> spawnPointsList = new(spawnPoints);

        // Randomly select spawn points
        List<Transform> selectedSpawnPoints = GetRandomSpawnPoints(spawnPointsList, toddlersToSpawn + preSchoolersToSpawn);

        if (selectedSpawnPoints.Count < toddlersToSpawn + preSchoolersToSpawn)
        {
            Debug.LogError("Not enough spawn points!");
            return;
        }

        // Spawn toddlers
        for (int i = 0; i < toddlersToSpawn; i++)
        {
            enemyManager.SpawnToddler(selectedSpawnPoints[i].position, GetRandomTarget().transform);
        }

        // Spawn preSchoolers
        for (int i = toddlersToSpawn; i < toddlersToSpawn + preSchoolersToSpawn; i++)
        {
            enemyManager.SpawnPreSchooler(selectedSpawnPoints[i].position, GetRandomTarget().transform);
        }
    }

    private GameObject GetRandomTarget()
    {
        // Example: Get a random player or sand castle transform as the target
        return Random.Range(0f, 1f) > 0.5f ? playerRig : sandCastleRig;
    }

    private List<Transform> GetRandomSpawnPoints(List<Transform> spawnPoints, int count)
    {
        // Create a copy of the spawn points list
        List<Transform> shuffledSpawnPoints = new List<Transform>(spawnPoints);

        // Shuffle the copied list
        for (int i = shuffledSpawnPoints.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (shuffledSpawnPoints[randomIndex], shuffledSpawnPoints[i]) = (shuffledSpawnPoints[i], shuffledSpawnPoints[randomIndex]);
        }

        // Return the first 'count' elements from the shuffled list
        return shuffledSpawnPoints.Take(count).ToList();
    }
}
