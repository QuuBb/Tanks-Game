using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    [SerializeField]
    public bool Player1;
    public GameObject bulletPrefab; // Prefabrykat pocisku
    public float bulletSpeed = 10f; // Pr�dko�� pocisku
    public float shootCooldown = 2f; // Czas odst�pu mi�dzy strza�ami
    private float lastShootTime; // Czas ostatniego strza�u
    public Transform bulletSpawnPoint;
    public AudioClip shootSound;
    private AudioSource audioSource;



    private void Start()
    {
        // Uzyskanie komponentu AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on the tank.");
        }
    }
    void Update()
    {
        // Strzelanie po wci�ni�ciu klawisza spacji i po up�ywie czasu od ostatniego strza�u
        if (Player1 == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShootTime + shootCooldown)
            {
                Debug.Log("Shooting");
                Shoot();
                lastShootTime = Time.time; // Zapisanie czasu ostatniego strza�u
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightShift) && Time.time > lastShootTime + shootCooldown)
            {
                Debug.Log("Shooting");
                Shoot();
                lastShootTime = Time.time; // Zapisanie czasu ostatniego strza�u
            }


        }
     
    }

    void Shoot()
    {
        // Instancjonowanie nowego pocisku w pozycji bulletSpawnPoint
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
        Debug.Log("Bullet instantiated");

        // Ignorowanie kolizji mi�dzy czo�giem a pociskiem
        Collider2D tankCollider = GetComponent<Collider2D>();
        Collider2D bulletCollider = bullet.GetComponent<Collider2D>();
        if (tankCollider != null && bulletCollider != null)
        {
            Physics2D.IgnoreCollision(tankCollider, bulletCollider);
        }
        else
        {
            Debug.LogError("Tank or bullet does not have a Collider2D component");
        }

        // Dodanie pr�dko�ci pociskowi w kierunku, w kt�rym jest obr�cony czo�g
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        audioSource.PlayOneShot(shootSound);

        if (rb != null)
        {
            rb.velocity = transform.up * bulletSpeed;
            Debug.Log("Bullet velocity set");
        }
        else
        {
            Debug.LogError("Bullet prefab does not have a Rigidbody2D component");
        }
    }
}
