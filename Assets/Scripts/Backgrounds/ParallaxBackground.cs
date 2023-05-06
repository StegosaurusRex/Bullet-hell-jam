using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    Material material;
    Vector2 offset;
    public int xVelocity, yVelocity;
    public bool startScroll=false;
    public float startScrollingTime;
    ToAnotherPlanetTrigger toAnotherPlanetTrigger;
    private void Start()
    {
        toAnotherPlanetTrigger = GameObject.FindObjectOfType<ToAnotherPlanetTrigger>();
    }
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        
    }
    private void Update()
    {
        
        if (toAnotherPlanetTrigger.isFlying==true)
        {
            StartCoroutine(StartScrolling());
        }
        
        if (startScroll == true)
        {
            offset = new Vector2(xVelocity , yVelocity);
            material.mainTextureOffset += offset * Time.deltaTime;
        }
        
    }
    IEnumerator StartScrolling()
    {

        yield return new WaitForSeconds(startScrollingTime);
        startScroll = true;

    }
}