using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToddlerEnemyCharacter : EnemyCharacter, IDamageable
{
    [Header("Toddler Attack Settings")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject noodle;

    public override void Attack(IDamageable _attackTarget)
    {
        noodle.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        Debug.Log($"Attacking the {_attackTarget}!");
        _attackTarget.TakeDamage(damage);
    }

    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
