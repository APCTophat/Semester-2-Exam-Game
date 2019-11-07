using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReasourceScript : MonoBehaviour
{
    public bool isFood;
    public bool isFuel;
    public bool isGold;

    public GameObject Food;
    public GameObject Fuel;
    public GameObject Gold;

    public int ReasourseAmount;
    public int AmountMax;
    public int AmountMin;

    public ParticleSystem FoodPillarParticles;
    public ParticleSystem FuelPillarParticles;
    public ParticleSystem GoldPillarParticles;
    public float SizeDivider;

    public AudioSource Clink;
    public AudioSource Clank;

    void Start()
    {
        Food.SetActive(false);
        Fuel.SetActive(false);
        Gold.SetActive(false);

        int index = Random.Range(1, 4);
        if(index == 1)
        {
            isFood = true;
        }
        else if(index == 2)
        {
            isFuel = true;
        }
        else if(index == 3)
        {
            isGold = true;
        }

        MoveToGroundLevel();
      
    }


   
    public void Active()
    {
        Clink.Play();
        if (isFood)
        {
            Food.SetActive(true);
            ReasourseAmount = Random.Range(AmountMin, AmountMax);
            float AmountPercentage = ReasourseAmount / 5;
            var main = FoodPillarParticles.main;
            main.startSize = AmountPercentage ;
          
        }
        else if (isFuel)
        {
            Fuel.SetActive(true);
            ReasourseAmount = Random.Range(AmountMin, AmountMax);
            float AmountPercentage = ReasourseAmount / 5;
            var main = FuelPillarParticles.main;
            main.startSize = AmountPercentage;

        }
        else if (isGold)
        {
            Gold.SetActive(true);
            ReasourseAmount = Random.Range(AmountMin, AmountMax);
            float AmountPercentage = ReasourseAmount / 5;
            var main = GoldPillarParticles.main;
            main.startSize = AmountPercentage;
           
        }
    }


    public void MoveToGroundLevel()
    {
        RaycastHit CheckGroundDist;
        if (Physics.Raycast(transform.position, Vector3.down, out CheckGroundDist))
        {
            var GroundDist = CheckGroundDist.distance;
            var CurrentPos = transform.position;
            transform.position = new Vector3(transform.position.x, CurrentPos.y - GroundDist, transform.position.z);
        }

        if (transform.position.y >= 10)
        {
            transform.position = new Vector3(Random.Range(-140, 140), 20, Random.Range(-140, 140));
            MoveToGroundLevel();
        }
    }

}
