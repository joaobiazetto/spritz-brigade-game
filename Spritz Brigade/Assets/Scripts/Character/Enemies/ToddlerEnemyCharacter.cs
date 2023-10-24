using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToddlerEnemyCharacter : EnemyCharacter, IDamageable
{
    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;

        if (currentHealth <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
