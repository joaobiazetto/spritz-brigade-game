using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private AssetReference toddlerPrefabAssetReference;
    [SerializeField] private AssetReference preSchoolerPrefabAssetReference;

    public void SpawnToddler(Vector3 position, Transform target)
    {
        SpawnEnemy(position, target, toddlerPrefabAssetReference);
    }

    public void SpawnPreSchooler(Vector3 position, Transform target)
    {
        SpawnEnemy(position, target, preSchoolerPrefabAssetReference);
    }

    private void SpawnEnemy(Vector3 position, Transform target, AssetReference prefabReference)
    {
        // Instantiate enemy prefab asynchronously using Addressables
        PrefabManager.Instance.InstantiatePrefabAsync(prefabReference, position, Quaternion.identity, instantiatedPrefab =>
        {
            // Handle additional setup or logic for the instantiated enemy
            // For example, setting the target for the enemy, initializing health, etc.
            EnemyCharacter enemy = instantiatedPrefab.GetComponent<EnemyCharacter>();
            if (enemy != null)
            {
                enemy.SetTarget(target); // Set the target for the specific enemy type
                enemy.Follow(); // Start following the assigned target
            }
        });
    }
}
