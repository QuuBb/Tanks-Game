using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public float duration = 3f; // Czas trwania eksplozji
    public AudioClip explosionSound; // DŸwiêk eksplozji

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

        // Jeœli istnieje dŸwiêk eksplozji, ustaw go
        if (explosionSound != null)
        {
            audioSource.clip = explosionSound;
        }

        // Odtwórz dŸwiêk eksplozji
        audioSource.Play();

        // Uruchom coroutine do usuwania eksplozji po okreœlonym czasie
        StartCoroutine(DestroyAfterDuration(duration));
    }

    void Update()
    {
        // Aktualizuj czas
        timer += Time.deltaTime;

        // Jeœli czas trwania eksplozji min¹³, zniszcz obiekt
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterDuration(float duration)
    {
        // Poczekaj przez okreœlony czas
        yield return new WaitForSeconds(duration);

        // Zniszcz obiekt eksplozji po up³ywie czasu
        Destroy(gameObject);
    }
}
