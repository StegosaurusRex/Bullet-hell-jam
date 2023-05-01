using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFlying : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public ToAnotherPlanetTrigger flyingBool;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (flyingBool.isFlying == true)
        {

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput , verticalInput);
            rb.velocity = movement * speed;

            // Shoot on left mouse button click
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab , firePoint.position , transform.rotation);
    }


    
}
