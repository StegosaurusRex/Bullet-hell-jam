using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public AudioClip shotSound; // Add this variable for the shot sound
    private AudioSource audioSource; // Add this variable for playing the sound
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletLifetime = 5f;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the audio source component
    }
    private void Update()
    {
        // Get position of mouse cursor in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate direction to shoot bullet
        Vector2 shootDir = mousePos - firePoint.position;

        // Shoot bullet
        if (Input.GetButtonDown("Fire1"))
        {
            // Play the shot sound
            audioSource.PlayOneShot(shotSound);
            GameObject bullet = Instantiate(bulletPrefab , firePoint.position , Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir.normalized * bulletSpeed;
            Destroy(bullet , bulletLifetime);
        }
    }
}