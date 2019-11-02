using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManagerScript : MonoBehaviour
{
    public GameObject Rover;

    public GameObject[] ReasourceSpawns;

    public float ReasourceArrayLength;
    public float RadarDistance;

    private void Start()
    {
        Rover = PlayerManager.instance.Rover;
    }

    public void ScanForReasources()
    {
        for (int i = 0; i < ReasourceArrayLength; i++)
        {
            float DistanceBetweenRoverAndReasource = Vector3.Distance(Rover.transform.position, ReasourceSpawns[i].transform.position);

            if(DistanceBetweenRoverAndReasource <= RadarDistance)
            {
                Debug.Log(ReasourceSpawns[i].name);
                ReasourceSpawns[i].GetComponent<ReasourceScript>().Active();
            }
        }
    }



}
