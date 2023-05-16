using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFlying : MonoBehaviour
{
    public AudioClip shotSound; // Add this variable for the shot sound
    private AudioSource audioSource; // Add this variable for playing the sound
    public bool stopFly=false;
    public float force = 10f; // The force to apply to the object
    private Rigidbody2D rb;
    public float speed = 5f;
    public float disableTime = 5f;
    public GameObject bulletPrefab;
    public GameObject plane;
    public Transform firePoint;
    public ToAnotherPlanetTrigger flyingBool;
    public float shotCooldown = 0.5f; // The time between shots
    private float shotTimer = 0f; // The time since the last shot
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); // Get the audio source component
    }
    void Update()
    {
        if (flyingBool.isFlying == true && stopFly == false)
        {

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput , verticalInput);
            rb.velocity = movement * speed;


            // Check if enough time has passed since the last shot
            if (shotTimer <= 0f && Input.GetButton("Fire1"))
            {
                // Fire the bullet and reset the timer
                Shoot();
                shotTimer = shotCooldown;
            }
            else
            {
                // Decrease the timer
                shotTimer -= Time.deltaTime;

            }
        }
        }

    void Shoot()
    {
        Instantiate(bulletPrefab , firePoint.position , transform.rotation);
        // Play the shot sound
        audioSource.PlayOneShot(shotSound);
    }

    IEnumerator DisablePlane()
    {
        
        yield return new WaitForSeconds(disableTime);
        stopFly = true;
        Animator animator = GetComponent<Animator>();
        // Get the script component on the object
        CameraOutOfBounds script = GetComponent<CameraOutOfBounds>();
        animator.SetTrigger("Fly");
        script.enabled = false;
        yield return new WaitForSeconds(3f);
        

    }
    public void DisablePlaneFly()
    {
        StartCoroutine(DisablePlane());
    }

}
