using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EnemyHP : MonoBehaviour
{
    public GameObject enemyDeathAnim;
    public GameObject enemyDeathAnimExit;
    public GameObject enemy;
    public int startHp;
    public int hp;
    public AudioClip impactShotSound;
    private AudioSource audioSource; // Add this variable for playing the sound

    public float bulletCooldown;
    public float timeToBlowUp;
    public float timeToSpawnNewEnemy;



    float bulletTimer;

    void Start()
    {
        hp = startHp;
        
        audioSource = GetComponent<AudioSource>(); // Get the audio source component
    }
    void Update()
    {
        bulletTimer -= Time.deltaTime;
        if (hp <= 0)
        {
            EnemyDeath();
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet" && bulletTimer <= 0)
        {
            hp -= 1;
            print(hp);
            bulletTimer = bulletCooldown;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(impactShotSound);
        }
    }
    IEnumerator DeathAnim()
    {
        enemyDeathAnim.SetActive(true);
        yield return new WaitForSeconds(timeToBlowUp);
        enemyDeathAnimExit.SetActive(false);
        enemy.SetActive(false);
        yield return new WaitForSeconds(timeToSpawnNewEnemy);
        
    }
    public void EnemyDeath()
    {
        StartCoroutine(DeathAnim());
    }
    
}
