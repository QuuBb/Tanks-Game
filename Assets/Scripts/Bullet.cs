using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // Prêdkoœæ pocisku
    public float fadeOutTime = 1f; // Czas, po którym pocisk zniknie
    public int damage = 10; // Obra¿enia pocisku
    public GameObject collisionPrefab; // Prefabrykat do umieszczenia w miejscu kolizji

    public GameObject owner; // W³aœciciel pocisku

    void Start()
    {
        // Dodaj prêdkoœæ pociskowi w kierunku, w którym jest obrócony
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }

    void Update()
    {

    }

    // Wywo³ywane, gdy obiekt trafia w inny obiekt z kolizj¹
    void OnCollisionEnter2D(Collision2D collision)
    {
        // SprawdŸ, czy obiekt, z którym koliduje, ma komponent Wall
        Wall wall = collision.gameObject.GetComponent<Wall>();
        if (wall != null)
        {
            // Jeœli obiekt ma komponent Wall, zadaj mu obra¿enia
            wall.TakeDamage(damage);
            Debug.Log("DMG!");
        }

        // Pobierz pozycjê kolizji
        Vector2 collisionPosition = collision.GetContact(0).point;
        // Utwórz trójwymiarowy wektor z wartoœci¹ Z równ¹ -1
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
