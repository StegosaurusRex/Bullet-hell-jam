using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerHP : MonoBehaviour
{
    public GameObject playerDeathAnim;
    public GameObject playerDeathAnimExit;
    public GameObject player;
    public int startHp;
    public int hp;
    public TextMeshProUGUI hpText;
    public float bulletCooldown;
    public float timeToBlowUp;
    float bulletTimer;
    void Start()
    {
        hp = startHp;
        hpText = GetComponent<TextMeshProUGUI>();
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
            
            StartCoroutine(DisableDeathAnim());
        }
        hpText.text = "HP: " + hp.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && bulletTimer <= 0)
        {
            hp -= 1;
            print(hp);
            bulletTimer = bulletCooldown;
        }
    }
    IEnumerator DisableDeathAnim()
    {
        playerDeathAnim.SetActive(true);
        yield return new WaitForSeconds(timeToBlowUp);
        playerDeathAnimExit.SetActive(false);
        player.SetActive(false);

    }

}
