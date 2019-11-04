using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManagerScript : MonoBehaviour
{
    public GameObject Rover;
    public GameObject ReasourceSource;

    public List<GameObject> theReasources = new List<GameObject>();

    public float ReasourceListLength;
    public float RadarDistance;
    public float StartingReasourcesNo;
    public float PickUpDistance;

    public float XSpawnMax;
    public float XSpawnMIn;
    public float ZSpawnMax;
    public float ZSpawnMin;


    /////The reasoures to be tracked Varables////
    public bool isfood;
    public bool isfuel;
    public bool isGold;

    public float AmountOfReasources;

    public float Food_Reasource;
    public float Fuel_reasource;
    public float Gold_Reasource;

    private void Start()
    {
        Rover = PlayerManager.instance.Rover;
        InitialSpawnReasource();
    }

    private void Update()
    {
        ReasourceListLength = theReasources.Count;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DestroyClosestReasource(theReasources);
        }
    }

    public void ScanForReasources()
    {
        for (int i = 0; i < ReasourceListLength; i++)
        {
            float DistanceBetweenRoverAndReasource = Vector3.Distance(Rover.transform.position, theReasources[i].transform.position);

            if(DistanceBetweenRoverAndReasource <= RadarDistance)
            {
                theReasources[i].GetComponent<ReasourceScript>().Active();
            }
        }
    }



    public void InitialSpawnReasource()
    {
        for (int i = 0; i < StartingReasourcesNo; i++)
        {
            GameObject NewReasource = Instantiate(ReasourceSource, new Vector3(Random.Range(XSpawnMIn, XSpawnMax),20, Random.Range(ZSpawnMin, ZSpawnMax)), Quaternion.identity);
            theReasources.Add(NewReasource);
        }
    }


    public void DestroyClosestReasource(List<GameObject> theReasource)
    {
        GameObject nearest = null;
        float Distance = 0;


        for (int i = 0; i < ReasourceListLength; i++)
        {
            float tempDist = Vector3.Distance(Rover.transform.position, theReasources[i].transform.position);

            if(nearest == null || tempDist < Distance)
            {
                nearest = theReasources[i];
                Distance = tempDist;

                isfood = theReasources[i].GetComponent<ReasourceScript>().isFood;
                isfuel = theReasources[i].GetComponent<ReasourceScript>().isFuel;
                isGold = theReasources[i].GetComponent<ReasourceScript>().isGold;

                AmountOfReasources = theReasources[i].GetComponent<ReasourceScript>().ReasourseAmount;
            }

        }

        if(Distance <= PickUpDistance)
        {
            if(isfood)
            {
                Food_Reasource += AmountOfReasources;
            }
            else if (isfuel)
            {
                Fuel_reasource += AmountOfReasources;
            }
            else if (isGold)
            {
                Gold_Reasource += AmountOfReasources;
            }


            theReasource.Remove(nearest);
            Destroy(nearest.gameObject);
        }
    }
}
