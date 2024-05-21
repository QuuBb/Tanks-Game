using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // Pr�dko�� pocisku
    public float fadeOutTime = 1f; // Czas, po kt�rym pocisk zniknie
    public int damage = 10; // Obra�enia pocisku

    private bool isFadingOut = false; // Czy pocisk zaczyna wygasa�
    private float fadeOutTimer = 0f; // Licznik czasu do wygasania

    void Start()
    {
        // Dodaj pr�dko�� pociskowi w kierunku, w kt�rym jest obr�cony
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }

    void Update()
    {
        // Je�li pocisk zaczyna wygasa�, zaktualizuj jego przezroczysto��
        if (isFadingOut)
        {
            fadeOutTimer += Time.deltaTime;
            float alpha = 1f - fadeOutTimer / fadeOutTime;
            Color bulletColor = GetComponent<SpriteRenderer>().color;
            bulletColor.a = alpha;
            GetComponent<SpriteRenderer>().color = bulletColor;

            // Je�li czas wygasania min��, zniszcz pocisk
            if (fadeOutTimer >= fadeOutTime)
            {
                Destroy(gameObject);
            }
        }
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
            // Zaczynamy proces wygasania pocisku
            isFadingOut = true;
        }
    }
}
