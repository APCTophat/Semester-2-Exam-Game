using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Transform Rover;
    NavMeshAgent agent;

    public float FindRoverRadius = 10f;



    private void Start()
    {
        Rover = PlayerManager.instance.Rover.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        //Vector3 dir = Rover.position - transform.position;
        //dir.y = 0; 
        //Quaternion rot = Quaternion.LookRotation(dir);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rot, 2 * Time.deltaTime);


        float distanceBetweenRover_Player = Vector3.Distance(Rover.position, transform.position);

        agent.SetDestination(Rover.position);

        //if (distanceBetweenRover_Player <= FindRoverRadius)
        //{
        //    agent.SetDestination(Rover.position);
        //}

        FaceRover();
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
