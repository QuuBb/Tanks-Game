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

    // Metoda do strzelania
    void Shoot()
    {
        // Instancjonowanie nowego pocisku
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Debug.Log("Bullet instantiated");

        // Dodanie pr�dko�ci pociskowi w kierunku, w kt�rym jest obr�cony czo�g
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
