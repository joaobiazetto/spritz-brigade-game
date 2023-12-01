using UnityEngine;

public class WaterGunWeapon : Weapon
{ 
    private void Start()
    {
        DestroyWaterBar();

        InstantiateWaterBar();
    }

    public override void Fire()
    {
        if (canFire && currentWaterAmmo > 0)
        {
            Debug.Log("Firing!");

            currentWaterAmmo--;

            waterBar.SetCurrentWaterAmmo(currentWaterAmmo);

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
        else if (currentWaterAmmo == 0)
        {
            Debug.Log("Out of Ammo! Time to reload!");
        }
    }
}
