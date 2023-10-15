using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class WaterGunWeapon : Weapon, IFireable
{
    public void Fire()
    {
        GameObject waterBullet = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        if (waterBullet.TryGetComponent<Rigidbody>(out var bulletRigidbody))
        {
            bulletRigidbody.velocity = projectileSpawnPoint.forward * projectileSpeed;
        }

        Destroy(waterBullet, projectileLifetime);
    }
}
