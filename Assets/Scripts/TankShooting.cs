using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    [SerializeField]
    public bool Player1;
    public GameObject bulletPrefab; // Prefabrykat pocisku
    public float bulletSpeed = 10f; // Prêdkoœæ pocisku
    public float shootCooldown = 2f; // Czas odstêpu miêdzy strza³ami
    private float lastShootTime; // Czas ostatniego strza³u
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
        // Strzelanie po wciœniêciu klawisza spacji i po up³ywie czasu od ostatniego strza³u
        if (Player1 == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShootTime + shootCooldown)
            {
                Debug.Log("Shooting");
                Shoot();
                lastShootTime = Time.time; // Zapisanie czasu ostatniego strza³u
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightShift) && Time.time > lastShootTime + shootCooldown)
            {
                Debug.Log("Shooting");
                Shoot();
                lastShootTime = Time.time; // Zapisanie czasu ostatniego strza³u
            }


        }
     
    }

    void Shoot()
    {
        // Instancjonowanie nowego pocisku w pozycji bulletSpawnPoint
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
        Debug.Log("Bullet instantiated");

        // Ignorowanie kolizji miêdzy czo³giem a pociskiem
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

        // Dodanie prêdkoœci pociskowi w kierunku, w którym jest obrócony czo³g
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
