using UnityEngine.AddressableAssets;

[System.Serializable]
public class EnemyWave
{
    public string waveName;
    public int enemyCount;
    public float spawnRate;

    public AssetReference enemyPrefab;
}
