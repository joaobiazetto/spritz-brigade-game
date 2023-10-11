using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablesInitializer : MonoBehaviour
{
    [SerializeField] private AssetReference waterGunWeaponPrefabAssetReference;
    [SerializeField] private AssetReference waterShotgunWeaponPrefabAssetReference;

    void Start()
    {
        // Initialize Addressables
        Addressables.InitializeAsync().Completed += OnAddressablesInitialized;
    }

    private void OnAddressablesInitialized(AsyncOperationHandle<IResourceLocator> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("Addressables initialized successfully");

            // Instantiate Water Gun prefab
            InstantiatePrefabAsync(waterGunWeaponPrefabAssetReference, () =>
            {
                // After Water Gun is instantiated, instantiate Water Shotgun
                InstantiatePrefabAsync(waterShotgunWeaponPrefabAssetReference, () =>
                {
                    Debug.Log("Both prefabs instantiated successfully");
                });
            });
        }
        else
        {
            Debug.LogError("Failed to initialize Addressables: " + obj.DebugName);
        }
    }

    private void InstantiatePrefabAsync(AssetReference prefabReference, System.Action onInstantiated = null)
    {
        // Instantiate prefab asynchronously
        prefabReference.InstantiateAsync(transform.position, Quaternion.identity).Completed += handle =>
        {
            OnPrefabInstantiated(handle);
            onInstantiated?.Invoke(); // Invoke the callback after instantiation
        };
    }

    private void OnPrefabInstantiated(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            // Access the instantiated GameObject
            GameObject instantiatedPrefab = handle.Result;

            // Do any additional setup or logic with the instantiated prefab
            Debug.Log("Prefab instantiated successfully: " + instantiatedPrefab.name);
        }
        else
        {
            Debug.LogError("Failed to instantiate prefab: " + handle.DebugName);
        }
    }
}
