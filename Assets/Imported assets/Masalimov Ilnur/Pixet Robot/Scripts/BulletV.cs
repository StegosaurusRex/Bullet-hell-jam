using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletV : MonoBehaviour
{

    public float speed;  
    public float lifetime;   
    public float distance;
    public LayerMask whatIsSolid;
    public bool isCharFacingRight = true;
    public bool isCharUp = false;
    Rigidbody2D rb;


    void Start()
    {
        Invoke("DestroyBullet", lifetime);
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = isCharFacingRight ? -transform.right : transform.right;
        Vector2 directionSecond = isCharUp ? transform.up:
        
        rb.velocity = direction * speed;
        rb.velocity = directionSecond * speed;
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)  
        {
            DestroyBullet();
        }
 
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);  
    }
}
