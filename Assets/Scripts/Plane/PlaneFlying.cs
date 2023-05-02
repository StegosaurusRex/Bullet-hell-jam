using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFlying : MonoBehaviour
{
    public bool stopFly=false;
    public float force = 10f; // The force to apply to the object
    private Rigidbody2D rb;
    public float speed = 5f;
    public float disableTime = 5f;
    public GameObject bulletPrefab;
    public GameObject plane;
    public Transform firePoint;
    public ToAnotherPlanetTrigger flyingBool;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (flyingBool.isFlying == true&&stopFly==false)
        {

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput , verticalInput);
            rb.velocity = movement * speed;

            if (stopFly==true) // Check if the spacebar is pressed
            {
                
            }
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

    IEnumerator DisablePlane()
    {
        
        yield return new WaitForSeconds(disableTime);
        stopFly = true;
        Animator animator = GetComponent<Animator>();

        animator.SetTrigger("Fly");

        yield return new WaitForSeconds(3f);
        Destroy(plane);

    }
    public void DisablePlaneFly()
    {
        StartCoroutine(DisablePlane());
    }

}
