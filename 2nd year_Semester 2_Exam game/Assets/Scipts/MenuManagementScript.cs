using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagementScript : MonoBehaviour
{
    public new Camera camera;
    public float CamRotSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camera.transform.Rotate(0, CamRotSpeed * Time.deltaTime, 0);
    }
}
