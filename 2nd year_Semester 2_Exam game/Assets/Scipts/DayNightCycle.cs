using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public bool isDay;

    public Light theSun;
    public float secondsInFullDay = 240f;
    [Range(0, 1)]
    public float CurrentTimeoFDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;

    float sunInitialIntensity;
   
    void Start()
    {
        sunInitialIntensity = theSun.intensity;
    }

   
    void Update()
    {
        UpdateSun();

        CurrentTimeoFDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if(CurrentTimeoFDay >= 1)
        {
            CurrentTimeoFDay = 0;
        }
    }

    void UpdateSun()
    {
        theSun.transform.localRotation = Quaternion.Euler((CurrentTimeoFDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if(CurrentTimeoFDay <= 0.1f || CurrentTimeoFDay >= 0.8f)
        {
            intensityMultiplier = 0;
            isDay = false;
        }
        else if(CurrentTimeoFDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((CurrentTimeoFDay - 0.1f) * (1 / 0.02f));
            isDay = true;

        }
        else if(CurrentTimeoFDay >= 0.8f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((CurrentTimeoFDay - 0.9f) * (1 / 0.02f)));
            isDay = true;
        }

        theSun.intensity = sunInitialIntensity * intensityMultiplier;


    }
}
