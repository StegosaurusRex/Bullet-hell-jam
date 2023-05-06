using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject disableCrosshair;
    public GameObject disableHP;
    public GameObject planeHP;
    ToAnotherPlanetTrigger toAnotherPlanetTrigger;
    // Start is called before the first frame update
    void Start()
    {
        toAnotherPlanetTrigger = GameObject.FindObjectOfType<ToAnotherPlanetTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toAnotherPlanetTrigger.isFlying==true)
        {
            disableCrosshair.SetActive(false);
            disableHP.SetActive(false);
            planeHP.SetActive(true);
        }
        else if (toAnotherPlanetTrigger.isFlying == false)
        {
            disableCrosshair.SetActive(true);
            disableHP.SetActive(true);
            planeHP.SetActive(false);
        }
    }
}
