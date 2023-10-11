using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShotgunWeapon : Weapon, IWeapon
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
