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

    // Metoda do strzelania
    void Shoot()
    {
        // Instancjonowanie nowego pocisku
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Debug.Log("Bullet instantiated");

        // Dodanie prêdkoœci pociskowi w kierunku, w którym jest obrócony czo³g
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
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
