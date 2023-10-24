using UnityEngine;
using UnityEngine.AddressableAssets;

public class PlayerCharacter : Character, IDamageable
{
    [SerializeField] private Transform weaponSpawnPoint;
    [SerializeField] private AssetReference waterGunPrefabAssetReference;
    [SerializeField] private AssetReference waterShotgunPrefabAssetReference;

    private IFireable currentWeapon;

    void Start()
    {
        Debug.Log("PlayerController Start");

        // Start with Water Gun
        SwitchToWaterGun();
    }

    private void Update()
    {
        // Check for input to switch weapons
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchToWaterShotgun();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchToWaterGun();
        }

        // Check for mouse click to fire
        if (Input.GetMouseButtonDown(0) && currentWeapon != null)
        {
            currentWeapon.Fire();
        }
    }

    private void SwitchToWaterShotgun()
    {
        // Destroy the current weapon
        DestroyCurrentWeapon();

        // Instantiate the Water Shotgun using PrefabManager
        PrefabManager.Instance.InstantiatePrefabAsync(waterShotgunPrefabAssetReference, instantiatedPrefab =>
        {
            currentWeapon = instantiatedPrefab.GetComponent<IFireable>();

            // Attach the weapon to the player
            AttachWeaponToPlayer();
        });
    }

    private void SwitchToWaterGun()
    {
        // Destroy the current weapon
        DestroyCurrentWeapon();

        // Instantiate the Water Gun using PrefabManager
        PrefabManager.Instance.InstantiatePrefabAsync(waterGunPrefabAssetReference, instantiatedPrefab =>
        {
            currentWeapon = instantiatedPrefab.GetComponent<IFireable>();

            // Attach the weapon to the player
            AttachWeaponToPlayer();
        });
    }

    private void DestroyCurrentWeapon()
    {
        if (currentWeapon != null && currentWeapon is MonoBehaviour weaponMono)
        {
            // Destroy the current weapon
            Destroy(weaponMono.gameObject);
        }
    }

    private void AttachWeaponToPlayer()
    {
        if (currentWeapon != null && currentWeapon is MonoBehaviour weaponMono)
        {
            // Attach the weapon to the player at the weapon spawn point
            weaponMono.transform.parent = weaponSpawnPoint;
            weaponMono.transform.localPosition = Vector3.zero;
            weaponMono.transform.localRotation = Quaternion.identity;
        }
    }

    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
