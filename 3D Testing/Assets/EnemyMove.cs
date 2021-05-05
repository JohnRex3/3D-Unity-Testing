using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent myNavMeshAgent;
    public Transform[] points;
    int currentPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        myNavMeshAgent.SetDestination(points[0].position);
    }

    // Update is called once per frame
    void Update()
    {
       // myNavMeshAgent.SetDestination(player.transform.position);
       if(myNavMeshAgent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }
    void GoToNextPoint()
    {
        currentPoint = (currentPoint + 1) % points.Length;
        myNavMeshAgent.SetDestination(points[currentPoint].position);
    }
}
