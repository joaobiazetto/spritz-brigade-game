using System.Collections;
using UnityEngine;

public class WaterGunWeapon : Weapon
{
    public override void Fire()
    {
        if (canFire && currentAmmo > 0)
        {
            currentAmmo--;

            GameObject waterBullet = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

            if (waterBullet.TryGetComponent<BulletController>(out var waterBulletComponent))
            {
                waterBulletComponent.damage = damage; // Set the damage value for the bullet
            }

            if (waterBullet.TryGetComponent<Rigidbody>(out var bulletRigidbody))
            {
                bulletRigidbody.velocity = projectileSpawnPoint.forward * projectileSpeed;
            }

            Destroy(waterBullet, projectileLifetime);

            StartCoroutine(Cooldown());
        }
        else if (currentAmmo == 0)
        {
            Reload();
        }
    }
}
