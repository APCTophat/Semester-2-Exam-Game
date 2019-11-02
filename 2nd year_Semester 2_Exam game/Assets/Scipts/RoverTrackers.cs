using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverTrackers : MonoBehaviour
{
    public Transform Rover;

    public GameObject Player;

    public bool isMoving;

    public float MaxXrot;
    public float bobtime;
    public float bobhight;
    
   
    Vector3 CamerDefault;


    private void Start()
    {
        Player = PlayerManager.instance.Player;
        Rover = PlayerManager.instance.Rover.transform;
    }


    private void Update()
    {
        transform.LookAt(Rover);
        isMoving = Player.GetComponent<PlayerController>().Moving;
        CamerDefault = new Vector3(transform.position.x, Player.transform.position.y + 2, transform.position.z);
        CameraBob();   ///turn on for camera bob
        if (transform.localEulerAngles.x >= MaxXrot && transform.localEulerAngles.x <= 180)
        {
            this.transform.localEulerAngles = new Vector3(MaxXrot, transform.rotation.y, transform.rotation.z);
            Debug.Log("broken Nek");
        }
    }

   
    void CameraBob()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp (transform.position, CamerDefault - Vector3.up * Mathf.Sin((Time.fixedTime) * bobtime) * bobhight, 5* Time.deltaTime);
        }
    }
}
