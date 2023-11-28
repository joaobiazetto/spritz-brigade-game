using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMeleeAttackController : MonoBehaviour
{
    private EnemyCharacter enemy;
    private IDamageable _attackTarget;
    private float lastAttackTime;

    private void Start()
    {
        enemy = GetComponent<EnemyCharacter>();
        lastAttackTime = enemy.attackCooldown;
        _attackTarget = null;
    }

    private void Update()
    {
        if (IsValidAttackTarget(_attackTarget))
        {
            if (IsReadyToAttack())
            {
                enemy.Attack(_attackTarget);
                lastAttackTime = Time.time;
            }
        }
        else
        {
            SetAttackTarget(null);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && !other.CompareTag(gameObject.tag))
        {
            IDamageable damageable = other.GetComponentInParent<IDamageable>();

            if (damageable == null)
            {
                Debug.Log("No IDamageable component found on the collided object.");
            }
            else
            {
                Debug.Log($"It's attacking {other.gameObject.tag}!");

                SetAttackTarget(damageable);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Out of attack range!");

        if (other.CompareTag("PlayerRig") || other.CompareTag("SandCastleRig"))
        {
            SetAttackTarget(null);
        }
    }

    public void SetAttackTarget(IDamageable target)
    {
        _attackTarget = target;
    }

    public bool IsValidAttackTarget(IDamageable attackTarget)
    {
        return attackTarget != null && !attackTarget.Equals(null);
    }

    private bool IsReadyToAttack()
    {
        return Time.time - lastAttackTime >= enemy.attackCooldown;
    }
}
