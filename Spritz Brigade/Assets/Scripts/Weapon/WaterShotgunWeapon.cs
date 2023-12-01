using UnityEngine;

public class WaterShotgunWeapon : Weapon
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
            currentWaterAmmo--;

            waterBar.SetCurrentWaterAmmo(currentWaterAmmo);

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
        else if (currentWaterAmmo == 0)
        {
            Debug.Log("Out of Ammo! Time to reload!");
        }
    }
}
