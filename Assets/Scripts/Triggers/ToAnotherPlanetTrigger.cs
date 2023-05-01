using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToAnotherPlanetTrigger : MonoBehaviour
{
    public bool isFlying;
    public GameObject player;
    public GameObject playerFlying;
    public GameObject plane;
    public float disableTime;
    public GameObject level;
    public GameObject sky;
    public GameObject space;
    public GameObject planeFly;
    public float time;//how much time for sky fall
    bool playerInTrigger = false; // Flag to keep track of whether the player is in the trigger area

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the trigger collided with the player
        {
            playerInTrigger = true; // Set the flag to true
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the trigger collided with the player
        {
            playerInTrigger = false; // Set the flag to false
        }
    }

    void Update()
    {
        
        
        if (playerInTrigger && Input.GetKey(KeyCode.E)) // Check if the player is in the trigger area and the E key is pressed
        {
            // Get a reference to the script component
            PlaneFlying flyingScript = planeFly.GetComponent<PlaneFlying>();
            Animator LevelAnim = level.GetComponent<Animator>();
            Animator SkyAnim = sky.GetComponent<Animator>();
            Animator SpaceAnim = space.GetComponent<Animator>();

            LevelAnim.SetTrigger("Fly");
            SkyAnim.SetTrigger("Fly");
            SpaceAnim.SetTrigger("Fly");
            isFlying = true;
            // Enable the script component
            flyingScript.enabled = true;

            StartCoroutine(DisablePlayer());
        }
    }

    IEnumerator DisablePlayer()
    {
        PlaneFlying flyingScript = planeFly.GetComponent<PlaneFlying>();
        player.SetActive(false);
        yield return new WaitForSeconds(disableTime);
        
        playerFlying.SetActive(true);
        playerFlying.transform.SetParent(null);
        flyingScript.enabled = false;
        //plane.transform.y

    }
}
