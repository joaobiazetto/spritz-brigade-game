using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IDamageable
{
    public Character _character;

    private PlayerHealthBar _playerHealthBar;

    private void Start()
    {
        _playerHealthBar = BarPrefabManager.Instance.CreatePlayerHealthBar(_character.maxHealth, HandleHealthBarInstantiated);
    }

    private void HandleHealthBarInstantiated(HealthBar healthBar)
    {
        if (healthBar is PlayerHealthBar playerHealthBar)
        {
            _playerHealthBar = playerHealthBar;
        }
        else
        {
            Debug.LogError("Unexpected type for healthBar");
        }
    }

    public void TakeDamage(float damageTaken)
    {
        if (_character == null) 
        {
            Debug.Log("No Character found!");
            return;
        }

        _character.currentHealth -= damageTaken;

        if (_playerHealthBar != null)
        {
            _playerHealthBar.SetCurrentHealth(_character.currentHealth);
        }
        else
        {
            Debug.LogWarning("PlayerHealthBar not instantiated or reference lost.");
        }

        if (_character.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
