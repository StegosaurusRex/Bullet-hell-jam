using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToAnotherPlanetTrigger : MonoBehaviour
{
    public GameObject player;
    public float disableTime;
    public GameObject level;
    public GameObject sky;
    public GameObject space;
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
            Animator LevelAnim = level.GetComponent<Animator>();
            Animator SkyAnim = sky.GetComponent<Animator>();
            Animator SpaceAnim = space.GetComponent<Animator>();
            LevelAnim.SetTrigger("Fly");
            SkyAnim.SetTrigger("Fly");
            SpaceAnim.SetTrigger("Fly");
            StartCoroutine(DisablePlayer());
        }
    }

    IEnumerator DisablePlayer()
    {
        player.SetActive(false);
        yield return new WaitForSeconds(disableTime);
        player.SetActive(true);
    }
}
