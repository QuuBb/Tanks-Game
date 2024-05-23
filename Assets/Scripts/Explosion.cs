using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public float duration = 3f; // Czas trwania eksplozji
    public AudioClip explosionSound; // D�wi�k eksplozji

    private SpriteRenderer spriteRenderer;
    private ParticleSystem particleSystem;
    private AudioSource audioSource;
    private float timer = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        particleSystem = GetComponent<ParticleSystem>();

        // Dodaj komponent AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();

        // Je�li istnieje d�wi�k eksplozji, ustaw go
        if (explosionSound != null)
        {
            audioSource.clip = explosionSound;
        }

        // Odtw�rz d�wi�k eksplozji
        audioSource.Play();

        // Uruchom coroutine do usuwania eksplozji po okre�lonym czasie
        StartCoroutine(DestroyAfterDuration(duration));
    }

    void Update()
    {
        // Aktualizuj czas
        timer += Time.deltaTime;

        // Je�li czas trwania eksplozji min��, zniszcz obiekt
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterDuration(float duration)
    {
        // Poczekaj przez okre�lony czas
        yield return new WaitForSeconds(duration);

        // Zniszcz obiekt eksplozji po up�ywie czasu
        Destroy(gameObject);
    }
}
