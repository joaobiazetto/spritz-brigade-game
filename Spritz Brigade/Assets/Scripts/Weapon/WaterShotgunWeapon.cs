using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShotgunWeapon : Weapon
{
    public override void Fire()
    {
        if (canFire && currentAmmo > 0)
        {
            currentAmmo--;

            GameObject waterShotgunBullet = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

            if (waterShotgunBullet.TryGetComponent<BulletController>(out var waterBulletComponent))
            {
                waterBulletComponent.damage = damage; // Set the damage value for the bullet
            }

            if (waterShotgunBullet.TryGetComponent<Rigidbody>(out var bulletRigidbody))
            {
                bulletRigidbody.velocity = projectileSpawnPoint.forward * projectileSpeed;
            }

            Destroy(waterShotgunBullet, projectileLifetime);

            StartCoroutine(Cooldown());
        }
        else if (currentAmmo == 0)
        {
            Debug.Log("Out of Ammo! Time to reload!");
        }
    }
}
