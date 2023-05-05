using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    Material material;
    Vector2 offset;
    public int xVelocity, yVelocity;
    public bool startScroll=false;
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        offset = new Vector2(xVelocity , yVelocity);
        if (startScroll == true)
        {
            material.mainTextureOffset += offset * Time.deltaTime;
        }
        
    }

}