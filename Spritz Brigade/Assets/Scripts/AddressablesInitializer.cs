using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablesInitializer : MonoBehaviour
{
    [SerializeField] private AssetReference waterGunWeaponPrefabAssetReference;
    [SerializeField] private AssetReference waterShotgunWeaponPrefabAssetReference;
    [SerializeField] private AssetReference toddlerPrefabAssetReference;
    [SerializeField] private AssetReference preSchoolerPrefabAssetReference;

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
        }
        else
        {
            Debug.LogError("Failed to initialize Addressables: " + obj.DebugName);
        }
    }

    private void InstantiateWaterGun(System.Action onInstantiated = null)
    {
        // Instantiate Water Gun prefab asynchronously
        InstantiatePrefabAsync(waterGunWeaponPrefabAssetReference, onInstantiated);
    }

    private void InstantiateWaterShotgun(System.Action onInstantiated = null)
    {
        // Instantiate Water Shotgun prefab asynchronously
        InstantiatePrefabAsync(waterShotgunWeaponPrefabAssetReference, onInstantiated);
    }

    private void InstantiateToddler(System.Action onInstantiated = null)
    {
        // Instantiate Water Shotgun prefab asynchronously
        InstantiatePrefabAsync(toddlerPrefabAssetReference, onInstantiated);
    }

    private void InstantiatePreSchooler(System.Action onInstantiated = null)
    {
        // Instantiate Water Shotgun prefab asynchronously
        InstantiatePrefabAsync(preSchoolerPrefabAssetReference, onInstantiated);
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
