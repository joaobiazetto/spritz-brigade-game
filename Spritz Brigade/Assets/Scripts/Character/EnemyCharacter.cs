using UnityEngine;

public abstract class EnemyCharacter : Character, IAttackable, IDamageable
{
    private Transform target;
    private EnemyMovementController movementController;

    private void Start()
    {
        movementController = GetComponent<EnemyMovementController>();
    }

    public abstract void Attack(IDamageable target, float damage);

    // Follow method to move towards the assigned target
    public void Follow()
    {
        if (target != null)
        {
            movementController.MoveToTarget(target);
        }
        else
        {
            Debug.LogWarning("No target assigned for enemy: " + gameObject.name);
        }
    }

    public void SetTarget(Transform target) { this.target = target; }

    public void TakeDamage(float damageTaken)
    {
        throw new System.NotImplementedException();
    }
}
