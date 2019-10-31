using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverTrackers : MonoBehaviour
{
    public Transform Rover;

    public GameObject Player;

    public bool isMoving;

    public float MaxXrot;
    public float Amplitude;
    public float Frequency;
    public float DefaultHight;
    public float LerpRate;
    public float PingPongTime;
    public float BobRange;

    Vector3 MaxBobHight;
    Vector3 MinBobHight;
    Vector3 CamerDefault;
    Vector3 tempPos;


    private void Start()
    {
        // posOffset = transform.position;
       
    }
    private void FixedUpdate()
    {
        transform.LookAt(Rover);
        isMoving = Player.GetComponent<PlayerController>().Moving;
        CamerDefault = new Vector3(transform.position.x, DefaultHight, transform.position.z);
        MaxBobHight = new Vector3(CamerDefault.x, CamerDefault.y + BobRange, CamerDefault.z);
        MinBobHight = new Vector3(CamerDefault.x, CamerDefault.y - BobRange, CamerDefault.z);

        if (transform.localEulerAngles.x >= MaxXrot && transform.localEulerAngles.x <= 180)
        {
            this.transform.localEulerAngles = new Vector3(MaxXrot, transform.rotation.y, transform.rotation.z);
            Debug.Log("broken Nek");
            
        }

       CameraBob();
    }

    void CameraBob()
    {
        if (isMoving)
        {
            //tempPos = this.transform.position;
            //tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * Frequency) * Amplitude;
            //transform.position = new Vector3(transform.position.x, tempPos.y, transform.position.z);

            //float time = Mathf.PingPong(Time.time * PingPongTime, 1);
            //transform.position = Vector3.Lerp(MinBobHight, MaxBobHight, time);


            transform.position = CamerDefault - Vector3.up * Mathf.Sin((Time.time + 1) * 1) * 1;
        }
        if (!isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, CamerDefault, LerpRate);
        }
    }
}
