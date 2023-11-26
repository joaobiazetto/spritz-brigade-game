using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreSchoolerEnemyCharacter : EnemyCharacter, IDamageable
{
    [Header("Pre Schooler Attack Settings")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject plasticShovel;

    public override void Attack(IDamageable attackTarget)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damageTaken)
    {
        throw new System.NotImplementedException();
    }
}
