﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverController : MonoBehaviour
{
    Rigidbody rb;

    public GameObject Scanner;
    public GameObject ReasourceManager;

    public float DriverSpeed;
    public float RotationAngle;
    public float RotationSpeed;

    public float MAX_Z_Rot;
    public float MAX_X_Rot;

    public bool isGrounded;
    public bool isOnWheels;

    public AudioSource Breathing;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Scanner = PlayerManager.instance.Scanner;
        ReasourceManager = PlayerManager.instance.ReasourceManager;
        StartCoroutine("PlaySound");
    }

   

    public void FixedUpdate()
    {
        float Drive = Input.GetAxis("RoverDriver");
        float Rotater = Input.GetAxis("RoverRotater") * RotationAngle;
        ScannerController();

        if (isOnWheels)
        {
            transform.position += transform.forward * Drive * DriverSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(0, Rotater, 0) * Time.deltaTime * RotationSpeed, Space.World);

        }

        CheckIfGrounded();
         
        if (Input.GetKeyDown(KeyCode.F) && isGrounded)
        {
            isGrounded = false;
            rb.useGravity = false;
            StartCoroutine("CorrectRoll", 1);
        }
    }

    IEnumerator PlaySound()
    {
        Breathing.Play();
        yield return new WaitForSeconds(Random.Range(30,50));
        StartCoroutine("PlaySound");
    }
 

 
    //the corutine for making the rover correct itself
    IEnumerator CorrectRoll(float timer)          
    {
        float elapsedTime = 0;

        while(elapsedTime < timer)
        {
            Quaternion Origin = Quaternion.Euler(0, transform.eulerAngles.y, 0);

           Vector3 GoPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, GoPos, Time.deltaTime * 0.5f);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               

            transform.rotation = Quaternion.Slerp(transform.rotation, Origin, Time.deltaTime * 5);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.useGravity = true;
    }


    void CheckIfGrounded()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down);
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isOnWheels = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isOnWheels = false;
    }

    void ScannerController()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Scanner.GetComponent<ScannerScript>().PlayAnimation();
            ReasourceManager.GetComponent<ResourceManagerScript>().ScanForReasources();

        }
    }
}
