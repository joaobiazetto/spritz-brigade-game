using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunWeapon : Weapon, IWeapon
{
    public void Fire()
    {
        // Instantiate a water bullet at the spawn point
        GameObject waterBullet = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        // Get the Rigidbody component of the water bullet
        
        if (waterBullet.TryGetComponent<Rigidbody>(out var bulletRigidbody))
        {
            // Set the initial velocity of the water bullet
            bulletRigidbody.velocity = projectileSpawnPoint.forward * projectileSpeed;
        }

        Destroy(waterBullet, projectileLifetime);
    }


}
