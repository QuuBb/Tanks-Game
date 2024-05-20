using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    [SerializeField]
    public GameObject bulletPrefab; // Prefabrykat pocisku
    public float bulletSpeed = 10f; // Pr�dko�� pocisku

    // Obiekt, kt�ry b�dzie zawiera� wszystkie pociski
    public Transform bulletContainer;

    // Update is called once per frame
    void Update()
    {
        // Strzelanie po wci�ni�ciu klawisza spacji
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

        // Dodanie pr�dko�ci pociskowi w kierunku, w kt�rym jest obr�cony czo�g
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }
}
