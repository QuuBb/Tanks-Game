using UnityEngine;

public class Wall : MonoBehaviour
{
    public int maxHealth = 2; // Maksymalna iloœæ punktów ¿ycia œciany
    private int currentHealth; // Aktualna iloœæ punktów ¿ycia
    public GameObject mapBlockPrefab; // Prefabrykat bloku mapy
    void Start()
    {
        currentHealth = maxHealth; // Ustaw aktualne punkty ¿ycia na maksymaln¹ wartoœæ
    }

    // Metoda do otrzymywania obra¿eñ

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Zmniejsz aktualne punkty ¿ycia o zadane obra¿enia

        // Jeœli aktualne punkty ¿ycia spad³y do zera i obiekt ma tag "Wall"
        if (currentHealth <= 0 && gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // Zniszcz zniszczon¹ œcianê

            // Utwórz blok mapy w miejscu zniszczonej œciany
            Instantiate(mapBlockPrefab, transform.position, Quaternion.identity);
        }
    }
   
}
