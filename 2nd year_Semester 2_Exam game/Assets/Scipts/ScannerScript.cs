using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerScript : MonoBehaviour
{

    public ParticleSystem ScanWave;

    public void PlayAnimation()
    {
        ScanWave.Emit(1);
    }
}
