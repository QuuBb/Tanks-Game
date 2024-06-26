using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float speed = 5f; // Pr�dko�� poruszania si� czo�gu
    public float rotationSpeed = 100f; // Pr�dko�� obracania si� czo�gu
    public int maxHealth = 5;
    public int health = 5; // Pocz�tkowa ilo�� �ycia czo�gu
    [SerializeField]
    private bool Player1;
    private Rigidbody2D rb; // Zmienna Rigidbody2D
    [SerializeField]
    private Vector3 SpawnPoint;
    [SerializeField]
    public HealthSlider HP;

    public AudioClip explosionSound; // Przypisz plik d�wi�kowy w inspektorze
    public GameObject explosionPrefab; // Przypisz prefabrykat eksplozji w inspektorze

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        // Pobierz komponent Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Ustawienie pozycji czo�gu na (0,0)
        transform.position = SpawnPoint; // Dla mapy 2D u�ywamy tylko dw�ch pierwszych wsp�rz�dnych (x, y)

        // Ustawienie Gravity Scale na 0, aby wy��czy� grawitacj�
        rb.gravityScale = 0;
    }

    void Update()
    {
        if (Player1)
        {
            // Poruszanie si� do przodu (strza�ki)
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
            }

            // Poruszanie si� do ty�u (strza�ki)
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.MovePosition(rb.position - (Vector2)transform.up * speed * Time.deltaTime);
            }

            // Obracanie w lewo (strza�ki)
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }

            // Obracanie w prawo (strza�ki)
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            // Poruszanie si� do przodu (WASD)
            if (Input.GetKey(KeyCode.W))
            {
                rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
            }

            // Poruszanie si� do ty�u (WASD)
            if (Input.GetKey(KeyCode.S))
            {
                rb.MovePosition(rb.position - (Vector2)transform.up * speed * Time.deltaTime);
            }

            // Obracanie w lewo (WASD)
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }

            // Obracanie w prawo (WASD)
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject != gameObject)
        {
            // Zatrzymaj oba czo�gi
            rb.velocity *= 0.1f;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= 0.3f;

        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            // Je�li kolizja ze �cian�, zatrzymaj ruch czo�gu
            rb.velocity = Vector2.zero;
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            // Je�li kolizja z pociskiem, zmniejsz zdrowie czo�gu
            health--;
            HP.UpdateSlider(health);

            // Je�li zdrowie wynosi 0 lub mniej, zniszcz czo�g
            if (health <= 0)
            {
                Debug.Log("Tank destroyed, playing explosion sound and spawning explosion effect");
                PlayExplosionSound();
                SpawnExplosionEffect();
                Destroy(gameObject);
            }

            // Zniszcz pocisk
            Destroy(collision.gameObject);
        }
    }

    void PlayExplosionSound()
    {
        if (explosionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(explosionSound);
            Debug.Log("Explosion sound played");
        }
        else
        {
            Debug.LogWarning("Explosion sound or audio source not set");
        }
    }

    void SpawnExplosionEffect()
    {
        if (explosionPrefab != null)
        {
            // Pobieramy bie��c� pozycj� i rotacj� obiektu
            Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;

            // Modyfikujemy pozycj� na osi Z
            position.z = -8;

            // Tworzymy instancj� eksplozji w nowej pozycji i z t� sam� rotacj�
            GameObject explosion = Instantiate(explosionPrefab, position, rotation);

            Debug.Log("Explosion effect spawned");
        }
        else
        {
            Debug.LogWarning("Explosion prefab not set");
        }
    }
}
