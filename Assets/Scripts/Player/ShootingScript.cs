using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public AudioClip shotSound;
    private AudioSource audioSource;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletLifetime = 5f;
    public float cooldownTime = 0.5f; // Add cooldown time variable
    private float lastShotTime; // Add variable to store time of last shot
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        // Get position of mouse cursor in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate direction to shoot bullet
        Vector2 shootDir = mousePos - firePoint.position;

        // Shoot bullet with cooldown
        if (Input.GetButton("Fire1") && Time.time - lastShotTime >= cooldownTime)
        {
            // Play the shot sound
            audioSource.PlayOneShot(shotSound);
            GameObject bullet = Instantiate(bulletPrefab , firePoint.position , Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir.normalized * bulletSpeed;
            Destroy(bullet , bulletLifetime);
            lastShotTime = Time.time; // Update last shot time
        }
    }
}