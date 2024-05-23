using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider slider; // Referencja do Slidera
    public Tank tank; // Referencja do skryptu zarz¹dzaj¹cego zdrowiem czo³gu

    void Start()
    {
        // Pobierz referencjê do Slidera, jeœli nie zosta³a ustawiona w inspektorze
        if (slider == null)
            slider = GetComponent<Slider>();

        // Pobierz referencjê do skryptu zarz¹dzaj¹cego zdrowiem czo³gu, jeœli nie zosta³a ustawiona w inspektorze
        if (tank == null)
            tank = FindObjectOfType<Tank>();

        // Zaktualizuj Slider na podstawie pocz¹tkowego zdrowia czo³gu
        UpdateSlider(5);
    }

    public void UpdateSlider(int hp)
    {
        // Ustaw wartoœæ Slidera na podstawie aktualnego zdrowia czo³gu
        slider.value = hp;
    }
}
