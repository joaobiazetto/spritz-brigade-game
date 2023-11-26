using UnityEngine;

public abstract class EnemyCharacter : Character, IAttackStrategy
{
    public float damage;
    public float attackCooldown;

    [Header("Attack Settings")]
    public IDamageable attackTarget;

    public abstract void Attack(IDamageable attackTarget);
}
