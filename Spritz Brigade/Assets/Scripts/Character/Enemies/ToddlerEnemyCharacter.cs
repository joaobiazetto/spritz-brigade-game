using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToddlerEnemyCharacter : EnemyCharacter
{
    public override void Attack(IDamageable target)
    {
        if (CanAttack())
        {
            // Perform the attack logic here
            Debug.Log($"{gameObject.name} is attacking!");
            target.TakeDamage(attackDamage);

            // Update the last attack time
            UpdateLastAttackTime();
        }
    }
}
