using UnityEngine;
using UnityEngine.AddressableAssets;

[System.Serializable]
public class EnemyWave
{
    public string waveName;
    [Range(3, 100)] public int enemyCount;
    public float spawnRate;

    public AssetReference enemyPrefab;
}
