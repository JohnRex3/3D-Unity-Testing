using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent myNavMeshAgent;
    public Transform[] waypoints;
    int currentWaypoint = 0;
    public float chaseRange = 10.0f;
    bool isChasing = false;

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        myNavMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        // myNavMeshAgent.SetDestination(player.transform.position);
       float distance = Vector3.Distance(player.transform.position, transform.position);
       if(distance < chaseRange)
        {
            myNavMeshAgent.SetDestination(player.transform.position);
            isChasing = true;
        }else if(isChasing)
        {
            myNavMeshAgent.SetDestination(waypoints[currentWaypoint].position);
            isChasing = false;
        }
       if(myNavMeshAgent.remainingDistance < 0.5f && !isChasing)
        {
            GoToNextWayPoint();
        }
    }
    void GoToNextWayPoint()
    {
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        myNavMeshAgent.SetDestination(waypoints[currentWaypoint].position);
    }
}
