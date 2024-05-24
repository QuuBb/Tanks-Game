using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // Pr�dko�� pocisku
    public float fadeOutTime = 1f; // Czas, po kt�rym pocisk zniknie
    public int damage = 10; // Obra�enia pocisku
    public GameObject collisionPrefab; // Prefabrykat do umieszczenia w miejscu kolizji

    public GameObject owner; // W�a�ciciel pocisku

    void Start()
    {
        // Dodaj pr�dko�� pociskowi w kierunku, w kt�rym jest obr�cony
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }

    void Update()
    {

    }

    // Wywo�ywane, gdy obiekt trafia w inny obiekt z kolizj�
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Sprawd�, czy obiekt, z kt�rym koliduje, ma komponent Wall
        Wall wall = collision.gameObject.GetComponent<Wall>();
        if (wall != null)
        {
            // Je�li obiekt ma komponent Wall, zadaj mu obra�enia
            wall.TakeDamage(damage);
            Debug.Log("DMG!");
        }

        // Pobierz pozycj� kolizji
        Vector2 collisionPosition = collision.GetContact(0).point;
        // Utw�rz tr�jwymiarowy wektor z warto�ci� Z r�wn� -1
        Vector3 collisionPosition3D = new Vector3(collisionPosition.x, collisionPosition.y, -3f);

        // Tworzymy prefabrykat w miejscu kolizji
        if (collisionPrefab != null)
        {
            Instantiate(collisionPrefab, collisionPosition3D, Quaternion.identity);
        }

        // Usuwamy pocisk
        Destroy(gameObject);
    }
}
