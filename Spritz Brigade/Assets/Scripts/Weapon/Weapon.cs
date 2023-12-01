using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class Weapon : MonoBehaviour, IFireable
{
    [Header("Weapon Settings")]
    [SerializeField] protected float damage;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected float projectileLifetime;
    [SerializeField] protected float cooldownTime;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected int maxWaterAmmo;

    public int currentWaterAmmo;

    [Header("Prefab Settings")]
    [SerializeField] protected Transform projectileSpawnPoint;
    [SerializeField] protected GameObject projectilePrefab;

    [Header("State")]
    [SerializeField] protected bool canFire = true;

    public AssetReference weaponWaterBarAssetReference;
    protected WaterBar waterBar;

    protected virtual void Awake()
    {
        currentWaterAmmo = maxWaterAmmo;
    }

    protected void InstantiateWaterBar()
    {
        PrefabManager.Instance.InstantiatePrefabAsync(weaponWaterBarAssetReference, instantiatedPrefab =>
        {
            waterBar = instantiatedPrefab.GetComponent<WaterBar>();

            waterBar.SetMaxWaterAmmo(maxWaterAmmo);
        });
    }

    protected void DestroyWaterBar()
    {
        Destroy(GameObject.FindGameObjectWithTag("WeaponWaterBar"));
    }

    public abstract void Fire();

    protected IEnumerator Cooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(cooldownTime);
        canFire = true;
    }

    public IEnumerator Reload()
    {
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);

        currentWaterAmmo = maxWaterAmmo;

        waterBar.SetCurrentWaterAmmo(currentWaterAmmo);
        Debug.Log("Reloaded!");
    }
}
