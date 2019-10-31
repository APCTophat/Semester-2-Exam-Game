using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public bool isMoving;

    public float LerpRate;
    public float DefaultHight;
    Vector3 CameraDeflaut;

    public float offset;
    public float period;
    public float hight;


    private void Start()
    {
        // CameraDeflaut = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        CameraDeflaut = transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       

        if (isMoving)
        {
            //tempPos = this.transform.position;
            //tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * Frequency) * Amplitude;
            //transform.position = new Vector3(transform.position.x, tempPos.y, transform.position.z);

            //float time = Mathf.PingPong(Time.time * PingPongTime, 1);
            //transform.position = Vector3.Lerp(MinBobHight, MaxBobHight, time);

           
            transform.position = CameraDeflaut - Vector3.up * Mathf.Sin((Time.time + offset) * period) * hight;
          
        }
        if (!isMoving)
        {
           // transform.position = Vector3.Lerp(transform.position, CameraDeflaut, LerpRate);
        }
    }
}
