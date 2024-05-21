using UnityEngine;

public class Wall : MonoBehaviour
{
    public int maxHealth = 2; // Maksymalna ilo�� punkt�w �ycia �ciany
    private int currentHealth; // Aktualna ilo�� punkt�w �ycia
    public GameObject mapBlockPrefab; // Prefabrykat bloku mapy
    void Start()
    {
        currentHealth = maxHealth; // Ustaw aktualne punkty �ycia na maksymaln� warto��
    }

    // Metoda do otrzymywania obra�e�

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Zmniejsz aktualne punkty �ycia o zadane obra�enia

        // Je�li aktualne punkty �ycia spad�y do zera i obiekt ma tag "Wall"
        if (currentHealth <= 0 && gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // Zniszcz zniszczon� �cian�

            // Utw�rz blok mapy w miejscu zniszczonej �ciany
            Instantiate(mapBlockPrefab, transform.position, Quaternion.identity);
        }
    }
   
}
