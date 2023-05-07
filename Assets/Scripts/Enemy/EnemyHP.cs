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


    public float bulletCooldown;
    public float timeToBlowUp;
    float bulletTimer;
    void Start()
    {
        hp = startHp;
        
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
        }
    }
    IEnumerator DeathAnim()
    {
        enemyDeathAnim.SetActive(true);
        yield return new WaitForSeconds(timeToBlowUp);
        enemyDeathAnimExit.SetActive(false);
        enemy.SetActive(false);

    }
    public void EnemyDeath()
    {
        StartCoroutine(DeathAnim());
    }

}
