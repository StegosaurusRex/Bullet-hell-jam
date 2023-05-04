using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    Material material;
    Vector2 offset;
    public int xVelocity, yVelocity;
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        offset = new Vector2(xVelocity , yVelocity);
        material.mainTextureOffset += offset * Time.deltaTime;
    }

}