using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    ToAnotherPlanetTrigger toAnotherPlanetTrigger;

    public AudioSource music1;
    public AudioSource music2;
    public AudioSource music3;
    private void Start()
    {
        toAnotherPlanetTrigger = FindAnyObjectByType<ToAnotherPlanetTrigger>();
    }
    void Update()
    {
        if (toAnotherPlanetTrigger.isFlying == true)
        {
            music1.Stop();
            music3.Stop();
            music2.Play();
        }
        if (toAnotherPlanetTrigger.isFlying == false)
        {
            music1.Play();
            music2.Stop();
            music3.Stop();
        }
        if (toAnotherPlanetTrigger.isThirdLevel == true&&toAnotherPlanetTrigger.isFlying==false)
        {
            music2.Stop();
            music1.Stop();
            music3.Play();
        }
    }
}
