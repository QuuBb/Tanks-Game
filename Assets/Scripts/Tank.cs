using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float speed = 5f; // Prêdkoœæ poruszania siê czo³gu
    public float rotationSpeed = 100f; // Prêdkoœæ obracania siê czo³gu
    public int health = 1; // Pocz¹tkowa iloœæ ¿ycia czo³gu
    [SerializeField]
    private bool Player1;
    private Rigidbody2D rb; // Zmienna Rigidbody2D

    void Start()
    {
        // Pobierz komponent Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Ustawienie pozycji czo³gu na (0,0)
        transform.position = new Vector3(0, 0, 0); // Dla mapy 2D u¿ywamy tylko dwóch pierwszych wspó³rzêdnych (x, y)

        // Ustawienie Gravity Scale na 0, aby wy³¹czyæ grawitacjê
        rb.gravityScale = 0;
    }

    void Update()
    {
        if(Player1)
        {
            // Poruszanie siê do przodu (strza³ki)
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
            }

            // Poruszanie siê do ty³u (strza³ki)
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.MovePosition(rb.position - (Vector2)transform.up * speed * Time.deltaTime);
            }

            // Obracanie w lewo (strza³ki)
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }

            // Obracanie w prawo (strza³ki)
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            // Poruszanie siê do przodu (WASD)
            if (Input.GetKey(KeyCode.W))
            {
                rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
            }

            // Poruszanie siê do ty³u (WASD)
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
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        // SprawdŸ, czy czo³g koliduje ze œcian¹
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collision with Wall detected.");
            // Jeœli tak, zatrzymaj ruch czo³gu
            rb.velocity = Vector2.zero;
        }
    }
}
