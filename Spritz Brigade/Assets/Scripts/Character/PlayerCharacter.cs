using UnityEngine;
using UnityEngine.AddressableAssets;

public class PlayerCharacter : Character, IDamageable
{
    [SerializeField] private Transform weaponSpawnPoint;
    [SerializeField] private AssetReference waterGunPrefabAssetReference;
    [SerializeField] private AssetReference waterShotgunPrefabAssetReference;

    private Weapon _currentWeapon;

    public HealthBarController healthBar;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);

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

        if (_currentWeapon != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _currentWeapon.Fire();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Player Reloading!");

                StartCoroutine(_currentWeapon.Reload());
            }
        }
    }

    private void SwitchToWaterShotgun()
    {
        // Destroy the current weapon
        DestroyCurrentWeapon();

        // Instantiate the Water Shotgun using PrefabManager
        PrefabManager.Instance.InstantiatePrefabAsync(waterShotgunPrefabAssetReference, instantiatedPrefab =>
        {
            _currentWeapon = instantiatedPrefab.GetComponent<Weapon>();

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
            _currentWeapon = instantiatedPrefab.GetComponent<Weapon>();

            // Attach the weapon to the player
            AttachWeaponToPlayer();
        });
    }

    private void DestroyCurrentWeapon()
    {
        if (_currentWeapon != null && _currentWeapon is MonoBehaviour weaponMono)
        {
            // Destroy the current weapon
            Destroy(weaponMono.gameObject);
        }
    }

    private void AttachWeaponToPlayer()
    {
        if (_currentWeapon != null && _currentWeapon is MonoBehaviour weaponMono)
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

        healthBar.SetCurrentHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
