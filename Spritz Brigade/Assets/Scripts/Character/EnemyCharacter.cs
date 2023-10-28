using UnityEngine;

public abstract class EnemyCharacter : Character
{
    public float damage;

    [Header("Attack Settings")]
    protected IDamageable attackTarget;

    protected virtual void Start()
    {
        attackTarget = null;
    }

    protected void SetAttackTarget(IDamageable target)
    {
        attackTarget = target;
    }

    protected bool IsValidAttackTarget(IDamageable attackTarget)
    {
        return attackTarget != null && !attackTarget.Equals(null);
    }
}
