using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SandCastleHealthController : MonoBehaviour, IDamageable
{
    public SandCastle _sandCastle;

    private SandCastleHealthBar _sandCastleHealthBar;

    private void Start()
    {
        _sandCastleHealthBar = BarPrefabManager.Instance.CreateSandCastleHealthBar(_sandCastle.maxHealth, HandleHealthBarInstantiated);
    }

    private void HandleHealthBarInstantiated(HealthBar healthBar)
    {
        if (healthBar is SandCastleHealthBar sandCastleHealthBar)
        {
            _sandCastleHealthBar = sandCastleHealthBar;
        }
        else
        {
            Debug.LogError("Unexpected type for healthBar");
        }
    }

    public void TakeDamage(float damageTaken)
    {
        if (_sandCastle == null)
        {
            Debug.Log("No Character found!");
            return;
        }

        _sandCastle.currentHealth -= damageTaken;

        if (_sandCastleHealthBar != null)
        {
            _sandCastleHealthBar.SetCurrentHealth(_sandCastle.currentHealth);
        }
        else
        {
            Debug.LogWarning("SandCastleHealthBar not instantiated or reference lost.");
        }

        if (_sandCastle.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
