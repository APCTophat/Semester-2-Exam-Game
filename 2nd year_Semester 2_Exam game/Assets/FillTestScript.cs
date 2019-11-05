using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillTestScript : MonoBehaviour
{
    public Image testfill;

    // Start is called before the first frame update
    void Start()
    {
        testfill.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        testfill.fillAmount += 0.02f * Time.deltaTime;
    }
}
