using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager _instance;

    public static EnemyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindWithTag("EnemyManager")?.GetComponent<EnemyManager>();

                if (_instance == null)
                {
                    GameObject managerObject = new GameObject("EnemyManager");
                    managerObject.tag = "EnemyManager";
                    _instance = managerObject.AddComponent<EnemyManager>();
                }
            }
            return _instance;
        }
    }

    public void SpawnEnemy(Vector3 position, AssetReference prefabReference)
    {
        GameObject target = Random.Range(0f, 1f) > 0.5f ? GameObject.FindWithTag("SandCastleRig") : GameObject.FindWithTag("PlayerRig");

        // Instantiate enemy prefab asynchronously using Addressables
        PrefabManager.Instance.InstantiatePrefabAsync(prefabReference, position, Quaternion.identity, instantiatedPrefab =>
        {
            // Handle additional setup or logic for the instantiated enemy
            EnemyMovementController enemyMovement = instantiatedPrefab.GetComponent<EnemyMovementController>();

            if (enemyMovement != null)
            {
                enemyMovement.SetTarget(target);
            }
        });
    }
}
