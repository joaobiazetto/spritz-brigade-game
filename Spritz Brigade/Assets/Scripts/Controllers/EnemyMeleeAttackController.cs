using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject noodle;

    private bool isAttacking;

    private EnemyCharacter enemy;
    private IDamageable attackTarget;

    protected virtual void Start()
    {
        isAttacking = false;

        enemy = GetComponent<EnemyCharacter>();
    }

    private void Update()
    {
        if (isAttacking)
        {
            noodle.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

            Debug.Log("Swinging the noodle!");

            if (attackTarget != null)
            {
                Debug.Log($"Attacking the {attackTarget}!");
                attackTarget.TakeDamage(enemy.damage);
            } 
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On attack range!");

        IDamageable damageable = other.GetComponentInParent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("It's attacking something!");

            isAttacking = true;
            SetAttackTarget(damageable);
        }
        else
        {
            Debug.Log("No IDamageable component found on the collided object.");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Out of attack range!");

        if (other.CompareTag("PlayerRig") || other.CompareTag("SandCastle"))
        {
            isAttacking = false;
        }
    }

    private void SetAttackTarget(IDamageable target)
    {
       attackTarget = target;
    }
}
