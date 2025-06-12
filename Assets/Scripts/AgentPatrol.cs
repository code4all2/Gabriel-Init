using UnityEngine;
using UnityEngine.AI;
public class AgentPatrol : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] int minDistancePoints = 1;
    int index;

    [SerializeField] Transform areaDetection;
    [SerializeField] float radiusDetection;
    [SerializeField] Vector3 offset;
    [SerializeField] LayerMask playerLayerMask;
    [SerializeField] Color gizmoColor = Color.white;

     // interação com o player
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(patrolPoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < minDistancePoints)
        {
            if (index >= patrolPoints.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }

            agent.SetDestination(patrolPoints[index].position);
        }

        StalkerPlayer();
        
    }

    void StalkerPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(areaDetection.position + offset, radiusDetection, playerLayerMask);

        foreach (Collider collider in colliders)
        {
            if(collider != null)
            {
                agent.SetDestination(collider.transform.position);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(areaDetection.position + offset, radiusDetection);
    }

}
