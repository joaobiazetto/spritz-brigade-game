using UnityEngine;
using UnityEngine.AddressableAssets;

public class PlayerCharacter : Character, IDamageable
{
    public AssetReference playerHealthBarPrefabAssetReference;
    private PlayerHealthBar _healthBar;

    void Start()
    {
        InstantiatePlayerHealthBar();
    }

    private void InstantiatePlayerHealthBar()
    {
        PrefabManager.Instance.InstantiatePrefabAsync(playerHealthBarPrefabAssetReference, instantiatedPrefab =>
        {
            _healthBar = instantiatedPrefab.GetComponent<PlayerHealthBar>();

            _healthBar.SetMaxHealth(maxHealth);
        });
    }

    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;

        _healthBar.SetCurrentHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
