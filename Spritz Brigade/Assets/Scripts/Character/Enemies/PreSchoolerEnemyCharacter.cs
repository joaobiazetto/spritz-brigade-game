using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreSchoolerEnemyCharacter : EnemyCharacter, IDamageable
{
    [Header("Pre Schooler Attack Settings")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject plasticShovel;

    private void Update()
    {
        if (attackTarget != null)
        {
            if (IsValidAttackTarget(attackTarget))
            {
                plasticShovel.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

                Debug.Log($"Attacking the {attackTarget}!");
                attackTarget.TakeDamage(damage);
            }
            else
            {
                SetAttackTarget(null);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On attack range!");

        if (other != null)
        {
            IDamageable damageable = other.GetComponentInParent<IDamageable>();

            if (damageable == null)
            {
                Debug.Log("No IDamageable component found on the collided object.");
            }
            else
            {
                Debug.Log("It's attacking something!");

                SetAttackTarget(damageable);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Out of attack range!");

        if (other.CompareTag("PlayerRig") || other.CompareTag("SandCastle"))
        {
            SetAttackTarget(null);
        }
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
