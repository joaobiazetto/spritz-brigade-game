using UnityEngine;

public abstract class EnemyCharacter : Character
{
    public float damage;

    [Header("Attack Settings")]
    public IDamageable attackTarget;

    protected virtual void Start()
    {
        attackTarget = null;
    }

    public void SetAttackTarget(IDamageable target)
    {
        attackTarget = target;
    }

    protected bool IsValidAttackTarget(IDamageable attackTarget)
    {
        return attackTarget != null && !attackTarget.Equals(null);
    }
}
