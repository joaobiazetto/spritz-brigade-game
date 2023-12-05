using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BarPrefabManager : MonoBehaviour
{
    private static BarPrefabManager _instance;

    public AssetReference _playerHealthBarPrefabAssetReference;
    public AssetReference _sandCastleHealthBarPrefabAssetReference;

    private GameObject _healthBar = null;
    private PlayerHealthBar _playerHealthBar = null;
    private SandCastleHealthBar _sandCastleHealthBar = null;

    public static BarPrefabManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindWithTag("BarPrefabManager")?.GetComponent<BarPrefabManager>();

                if (_instance == null)
                {
                    GameObject managerObject = new GameObject("BarPrefabManager");
                    managerObject.tag = "BarPrefabManager";
                    _instance = managerObject.AddComponent<BarPrefabManager>();
                }
            }
            return _instance;
        }
    }

    public PlayerHealthBar CreatePlayerHealthBar(float maxHealth, Action<PlayerHealthBar> callback)
    {
        CreateHealthBar(_playerHealthBarPrefabAssetReference, instantiatedPrefab =>
        {
            _playerHealthBar = instantiatedPrefab.GetComponent<PlayerHealthBar>();
            _playerHealthBar.SetMaxHealth(maxHealth);
            callback?.Invoke(_playerHealthBar);
        });

        return _playerHealthBar;
    }

    public SandCastleHealthBar CreateSandCastleHealthBar(float maxHealth, Action<SandCastleHealthBar> callback)
    {
        CreateHealthBar(_sandCastleHealthBarPrefabAssetReference, instantiatedPrefab =>
        {
            _sandCastleHealthBar = instantiatedPrefab.GetComponent<SandCastleHealthBar>();
            _sandCastleHealthBar.SetMaxHealth(maxHealth);
            callback?.Invoke(_sandCastleHealthBar);
        });

        return _sandCastleHealthBar;
    }

    private void CreateHealthBar(AssetReference prefabReference, Action<GameObject> callback)
    {
        // Instantiate Health Bar asynchronously using Addressables
        PrefabManager.Instance.InstantiatePrefabAsync(prefabReference, instantiatedPrefab =>
        {
            _healthBar = instantiatedPrefab;
            callback?.Invoke(_healthBar);
            Debug.LogWarning($"It's a {_healthBar.tag}.");
        });
    }
}
