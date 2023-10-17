using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IFireable
{
    [Header("Weapon Settings")]
    [SerializeField] protected float damage;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected float projectileLifetime;
    [SerializeField] protected float cooldownTime;
    [SerializeField] protected int maxAmmo;

    protected int currentAmmo;

    [Header("Prefab Settings")]
    [SerializeField] protected Transform projectileSpawnPoint;
    [SerializeField] protected GameObject projectilePrefab;

    [Header("State")]
    [SerializeField] protected bool canFire = true;

    protected virtual void Start()
    {
        currentAmmo = maxAmmo;
    }

    public abstract void Fire();

    protected IEnumerator Cooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(cooldownTime);
        canFire = true;
    }

    protected void Reload()
    {
        // Add any reload animations or logic here
        Debug.Log("Reloading...");
        currentAmmo = maxAmmo;
        Debug.Log("Reloaded!");
    }
}
