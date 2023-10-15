using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Call this method to make the enemy move to a target
    public void MoveToTarget(Transform targetTransform)
    {
        navMeshAgent.SetDestination(targetTransform.position);
    }
}
