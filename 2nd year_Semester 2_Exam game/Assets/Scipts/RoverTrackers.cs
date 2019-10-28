using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverTrackers : MonoBehaviour
{
    public Transform Rover;

    private void FixedUpdate()
    {
        transform.LookAt(Rover);
    }
}
