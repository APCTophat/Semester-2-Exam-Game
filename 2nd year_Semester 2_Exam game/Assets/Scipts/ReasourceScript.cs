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
        }
        else if (isFuel)
        {
            Fuel.SetActive(true);
        }
        else if (isGold)
        {
            Gold.SetActive(true);
        }
    }

    public void DestroyReasource()
    {
        Destroy(gameObject);
    }
}
