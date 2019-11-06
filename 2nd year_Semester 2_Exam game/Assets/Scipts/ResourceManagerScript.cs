using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManagerScript : MonoBehaviour
{
    public GameObject Rover;
    public GameObject ReasourceSource;
    public GameObject SceneManager;

    public List<GameObject> theReasources = new List<GameObject>();


    //Variables relating to the list tracking and spawn location of the reasources
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
    public float MaxFood;
    public float Fuel_reasource;
    public float MaxFuel;
    public float Gold_Reasource;

    public float MaxReasourcesOnMap;
    public float GameTime = 0f;
    public float DivideGameTime;

    /////// Menu UI////////
    public Image FoodBar;
    public Image FuelBar;

    public Text GoldAmount;

    public float FoodStartAmount;
    public float FoodContantBurnAmount;
    public float FuelStartAmount;
   //public float FuelConstantBurnAmount;
    public float FuelActionBurnAmount;

 
    public float FoodFillAmount;
    public float FuelFillAMount;
   

    private void Start()                           //finds Rover, Spawns initial Reasources, sets initial survival variables
    {
        SceneManager = PlayerManager.instance.SceneManager;
        Rover = PlayerManager.instance.Rover;
        InitialSpawnReasource();

        Food_Reasource = FoodStartAmount;
        Fuel_reasource = FuelStartAmount;
        Gold_Reasource = 0f;

        SpawnTImer();
    }

    private void Update()
    {
        ReasourceListLength = theReasources.Count;
        GameTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DestroyClosestReasource(theReasources);
        }
        if (Input.GetKeyDown(KeyCode.B))       ///needs to be removed is just a place holder
        {
            SpawnAReasource();
            PlayerPrefs.SetInt("HighScore", 0);
        }

        MenuUpdater();
        CheckIfPlayerIsDead();
        GoldTracker();
    }

    public void ScanForReasources()                           //checks distance between rover and each reasource, revels reasources that are in a certain range
    {
        for (int i = 0; i < ReasourceListLength; i++)
        {
            float DistanceBetweenRoverAndReasource = Vector3.Distance(Rover.transform.position, theReasources[i].transform.position);

            if(DistanceBetweenRoverAndReasource <= RadarDistance)
            {
                theReasources[i].GetComponent<ReasourceScript>().Active();
            }
        }

        Fuel_reasource -= FuelActionBurnAmount;                  //consumes fuel to scan
    }

    public void SpawnTImer()
    {
        StartCoroutine("InstanciateReasource");
    }

    IEnumerator InstanciateReasource()
    {
        yield return new WaitForSeconds(30 + (GameTime / DivideGameTime));
        SpawnAReasource();
        SpawnTImer();
    }

    public void InitialSpawnReasource()                  //does the initial spawn, the NO. determined by a variable, spawns then adds them to list
    {
        for (int i = 0; i < StartingReasourcesNo; i++)
        {
            GameObject NewReasource = Instantiate(ReasourceSource, new Vector3(Random.Range(XSpawnMIn, XSpawnMax),20, Random.Range(ZSpawnMin, ZSpawnMax)), Quaternion.identity);
            theReasources.Add(NewReasource);
        }
    }

    public void SpawnAReasource()                     //spawns then adds to list a reasource
    {
        if (ReasourceListLength <= MaxReasourcesOnMap)
        {
            GameObject NewReasource = Instantiate(ReasourceSource, new Vector3(Random.Range(XSpawnMIn, XSpawnMax), 20, Random.Range(ZSpawnMin, ZSpawnMax)), Quaternion.identity);
            theReasources.Add(NewReasource);
        }
        
    }

    public void DestroyClosestReasource(List<GameObject> theReasource)                    //scans for the closest reasource to the rover
    {                                                                                     //removes it from the scene and the list if it 1 unit to the rover
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

        if(Distance <= PickUpDistance)                                 //adds the value of the reasource to the respective reasource type depending on the resource collected
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

    public void MenuUpdater()                        //updates the UI to reflect the current values of each reasource
    {

        if(Food_Reasource >= MaxFood)
        {
            Food_Reasource = MaxFood;
        }
        Food_Reasource = Food_Reasource - FoodContantBurnAmount * Time.deltaTime;
        FoodFillAmount = Food_Reasource / MaxFood;
        FoodBar.fillAmount = FoodFillAmount;

        if(Fuel_reasource >= MaxFuel)
        {
            Fuel_reasource = MaxFuel;
        }
        //Fuel_reasource = Fuel_reasource - FuelConstantBurnAmount * Time.deltaTime;
        FuelFillAMount = Fuel_reasource / MaxFuel;
        FuelBar.fillAmount = FuelFillAMount;

        GoldAmount.text = Gold_Reasource.ToString();
    }



    public void CheckIfPlayerIsDead()
    {
        if(Food_Reasource <= -1)
        {
            //player is dead
           // SceneManager.GetComponent<sceneManagerScript>().LoadEndCreditScene();

        }
        else if(Fuel_reasource <= -10)
        {
            //rover is dead
           // SceneManager.GetComponent<sceneManagerScript>().LoadEndCreditScene();
        }
    }

    public void GoldTracker()
    {
        PlayerPrefs.SetInt("MoneyEarned", (int)Gold_Reasource);
    }
    public void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MoneyEarned", 0);
    }
}
