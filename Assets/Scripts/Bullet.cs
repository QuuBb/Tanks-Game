using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // Prêdkoœæ pocisku
    public float fadeOutTime = 1f; // Czas, po którym pocisk zniknie
    public int damage = 10; // Obra¿enia pocisku

    private bool isFadingOut = false; // Czy pocisk zaczyna wygasaæ
    private float fadeOutTimer = 0f; // Licznik czasu do wygasania

    void Start()
    {
        // Dodaj prêdkoœæ pociskowi w kierunku, w którym jest obrócony
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }

    void Update()
    {
        // Jeœli pocisk zaczyna wygasaæ, zaktualizuj jego przezroczystoœæ
        if (isFadingOut)
        {
            fadeOutTimer += Time.deltaTime;
            float alpha = 1f - fadeOutTimer / fadeOutTime;
            Color bulletColor = GetComponent<SpriteRenderer>().color;
            bulletColor.a = alpha;
            GetComponent<SpriteRenderer>().color = bulletColor;

            // Jeœli czas wygasania min¹³, zniszcz pocisk
            if (fadeOutTimer >= fadeOutTime)
            {
                Destroy(gameObject);
            }
        }
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
            // Zaczynamy proces wygasania pocisku
            isFadingOut = true;
        }
    }
}
