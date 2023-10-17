using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCastle : MonoBehaviour, IDamageable
{
    public int maxHealth = 50;
    public float currentHealth;

    public SandCastle ()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
    }
}
