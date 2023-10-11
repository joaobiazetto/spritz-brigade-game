using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerCharacter : Character
{
    [SerializeField] private Transform weaponSpawnPoint;
    [SerializeField] private AssetReference waterGunPrefabAssetReference;
    [SerializeField] private AssetReference waterShotgunPrefabAssetReference;

    private IWeapon currentWeapon;

    void Start()
    {
        Debug.Log("PlayerController Start");

        // Start with Water Gun
        EquipWeapon(waterGunPrefabAssetReference);
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

        // Check for mouse click to fire
        if (Input.GetMouseButtonDown(0) && currentWeapon != null)
        {
            currentWeapon.Fire();
        }
    }

    private void SwitchToWaterShotgun()
    {
        // Destroy the current weapon
        Destroy(currentWeapon as MonoBehaviour);

        // Equip the Water Shotgun
        EquipWeapon(waterShotgunPrefabAssetReference);
    }

    private void SwitchToWaterGun()
    {
        // Destroy the current weapon
        Destroy(currentWeapon as MonoBehaviour);

        // Equip the Water Gun
        EquipWeapon(waterGunPrefabAssetReference);
    }

    private void EquipWeapon(AssetReference weaponPrefabReference)
    {
        // Instantiate and equip the specified weapon using the PrefabManager
        PrefabManager.Instance.InstantiatePrefabAsync(weaponPrefabReference, weaponSpawnPoint.position, Quaternion.identity, instantiatedPrefab =>
        {
            currentWeapon = instantiatedPrefab.GetComponent<IWeapon>();

            // Attach the weapon to the player
            AttachWeaponToPlayer();

            // Additional setup or logic for the weapon if needed
        });
    }

    private void AttachWeaponToPlayer()
    {
        if (currentWeapon != null && currentWeapon is MonoBehaviour weaponMono)
        {
            // Attach the weapon to the player at the weapon spawn point
            weaponMono.transform.parent = weaponSpawnPoint;
            weaponMono.transform.localPosition = Vector3.zero;
            weaponMono.transform.localRotation = Quaternion.identity;
        }
    }
}
