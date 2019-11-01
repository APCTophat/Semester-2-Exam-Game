using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerScript : MonoBehaviour
{

    public ParticleSystem ScanWave;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("find");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
          //  ScanWave.emission.enabled = true;
        }
    }
}
