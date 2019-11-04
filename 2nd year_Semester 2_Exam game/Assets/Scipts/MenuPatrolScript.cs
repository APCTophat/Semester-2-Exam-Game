using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MenuPatrolScript : MonoBehaviour
{
    public GameObject[] WayPoints;
    public int CurrWayPoint = 0;

    public NavMeshAgent agent;


    // Update is called once per frame
    void Update()
    {
        if (WayPoints.Length == 0) return;

        float Dist = Vector3.Distance(WayPoints[CurrWayPoint].transform.position, this.transform.position);
        if(Dist <= 2)
        {
            CurrWayPoint++;
            if(CurrWayPoint >= WayPoints.Length)
            {
                CurrWayPoint = 0;
            }
        }

        agent.SetDestination(WayPoints[CurrWayPoint].transform.position);
        
    }
}
