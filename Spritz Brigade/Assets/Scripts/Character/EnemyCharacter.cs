using UnityEngine;

public abstract class EnemyCharacter : Character, IAttackable, IDamageable
{
    [SerializeField] protected Transform target;
    private EnemyMovementController movementController;

    protected float attackDamage;
    protected float attackInterval;
    private float lastAttackTime;

    private void Start()
    {
        movementController = GetComponent<EnemyMovementController>();
    }

    private void Update()
    {
        Follow();
    }

    public abstract void Attack(IDamageable target);

    // Follow method to move towards the assigned target
    public void Follow()
    {
        if (target != null)
        {
            Debug.Log($"Following target: {target.position}");
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
        currentHealth -= damageTaken;
    }

    protected bool CanAttack()
    {
        return Time.time - lastAttackTime >= attackInterval;
    }

    // Add this method to update the last attack time
    protected void UpdateLastAttackTime()
    {
        lastAttackTime = Time.time;
    }
}
