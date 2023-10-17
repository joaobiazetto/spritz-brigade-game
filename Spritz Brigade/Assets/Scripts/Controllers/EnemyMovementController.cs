using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;
    }

    // Call this method to make the enemy move to a target
    public void MoveToTarget(Transform targetTransform)
    {
        Debug.Log($"Moving to target: {targetTransform.position}");
        navMeshAgent.SetDestination(targetTransform.position);
    }
}
