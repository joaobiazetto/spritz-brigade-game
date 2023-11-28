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
    [SerializeField] private AssetReference playerHealthBarAssetReference;
    [SerializeField] private AssetReference enemyHealthBarAssetReference;
    [SerializeField] private AssetReference weaponWaterBarAssetReference;

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
}
