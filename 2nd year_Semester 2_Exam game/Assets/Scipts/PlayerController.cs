using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Transform Rover;
    NavMeshAgent agent;

    public bool Moving;

    public float FindRoverRadius = 10f;

    private Vector3 LastPos;

    private void Start()
    {
        Rover = PlayerManager.instance.Rover.transform;
        agent = GetComponent<NavMeshAgent>();
        LastPos = agent.velocity;
    }

    private void FixedUpdate()
    {
        float distanceBetweenRover_Player = Vector3.Distance(Rover.position, transform.position);

        agent.SetDestination(Rover.position);
        FaceRover();
 
        var CurrentPos = agent.velocity;
        if(CurrentPos == LastPos)
        {
            Moving = false;
        }
        else
        {
            Moving = true;
        }
        LastPos = CurrentPos;
    }


    void FaceRover()
    {
        Vector3 direction = (Rover.position - transform.position).normalized;
        Quaternion loookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, loookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FindRoverRadius);
    }
}
