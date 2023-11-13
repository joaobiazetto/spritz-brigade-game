using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent navMeshAgent;

    private EnemyCharacter enemy;

    private void Start()
    {
        enemy = gameObject.GetComponent<EnemyCharacter>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;
        navMeshAgent.speed = enemy.moveSpeed;
    }

    private void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
