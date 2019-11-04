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

       
        RaycastHit CheckGroundDist;
        if(Physics.Raycast(transform.position, Vector3.down, out CheckGroundDist))
        {
            var GroundDist = CheckGroundDist.distance;
            var CurrentPos = transform.position;
            transform.position = new Vector3(transform.position.x, CurrentPos.y - GroundDist, transform.position.z);
        }


    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            Active();
        }
    }

    public void Active()
    {
        if (isFood)
        {
            Food.SetActive(true);
            ReasourseAmount = Random.Range(AmountMin, AmountMax);
        }
        else if (isFuel)
        {
            Fuel.SetActive(true);
            ReasourseAmount = Random.Range(AmountMin, AmountMax);
        }
        else if (isGold)
        {
            Gold.SetActive(true);
            ReasourseAmount = Random.Range(AmountMin, AmountMax);
        }
    }

    //public void DestroyReasource()
    //{
    //    Destroy(gameObject);
    //}
}
