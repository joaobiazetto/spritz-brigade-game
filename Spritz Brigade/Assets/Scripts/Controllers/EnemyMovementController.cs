using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerRig");
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;
    }

    private void Update()
    {
        navMeshAgent.SetDestination(target.transform.position);
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
