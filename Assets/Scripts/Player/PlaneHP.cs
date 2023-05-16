using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlaneHP : MonoBehaviour
{
    public GameObject playerDeathAnim;
    public GameObject playerDeathAnimExit;
    public GameObject player;
    public int startHp;
    public int hp;
    public TextMeshProUGUI hpText;
    public AudioClip shotSound; // Add this variable for the shot sound
    private AudioSource audioSource; // Add this variable for playing the sound
    public float bulletCooldown;
    public float timeToBlowUp;
    float bulletTimer;
    ToAnotherPlanetTrigger toAnotherPlanetTrigger;
    public AudioClip impactShotSound; // Add this variable for the shot sound
    void Start()
    {
        toAnotherPlanetTrigger = FindAnyObjectByType<ToAnotherPlanetTrigger>();
        hp = startHp;
        audioSource = GetComponent<AudioSource>(); // Get the audio source component
        if (hpText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found!");
        }
    }
    void Update()
    {
        bulletTimer -= Time.deltaTime;
        if (hp <= 0)
        {
            PlayerDeath();
            
        }
        hpText.text="HP: "+hp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && bulletTimer <= 0&&toAnotherPlanetTrigger.isFlying==true)
        {
            hp -= 1;
            print(hp);
            bulletTimer = bulletCooldown;
            audioSource.PlayOneShot(impactShotSound);
        }
    }
    IEnumerator DeathAnim()
    {
        playerDeathAnim.SetActive(true);
        yield return new WaitForSeconds(timeToBlowUp);
        playerDeathAnimExit.SetActive(false);
        player.SetActive(false);

    }
    public void PlayerDeath()
    {
        StartCoroutine(DeathAnim());
    }

}
