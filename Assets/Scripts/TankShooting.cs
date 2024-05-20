using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    [SerializeField]
    public GameObject bulletPrefab; // Prefabrykat pocisku
    public float bulletSpeed = 10f; // Prêdkoœæ pocisku

    // Obiekt, który bêdzie zawiera³ wszystkie pociski
    public Transform bulletContainer;

    // Update is called once per frame
    void Update()
    {
        // Strzelanie po wciœniêciu klawisza spacji
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // Metoda do strzelania
    void Shoot()
    {
        // Instancjonowanie nowego pocisku jako dziecko obiektu bulletContainer
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.transform.SetParent(bulletContainer);

        // Dodanie prêdkoœci pociskowi w kierunku, w którym jest obrócony czo³g
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }
}
