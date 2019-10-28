using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform PlayersEyes;

    public Camera theCamera;

    private void LateUpdate()
    {
        theCamera.transform.position = PlayersEyes.position;
        theCamera.transform.rotation = PlayersEyes.rotation;
    }

}
