using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider slider; // Referencja do Slidera
    public Tank tank; // Referencja do skryptu zarz�dzaj�cego zdrowiem czo�gu

    void Start()
    {
        // Pobierz referencj� do Slidera, je�li nie zosta�a ustawiona w inspektorze
        if (slider == null)
            slider = GetComponent<Slider>();

        // Pobierz referencj� do skryptu zarz�dzaj�cego zdrowiem czo�gu, je�li nie zosta�a ustawiona w inspektorze
        if (tank == null)
            tank = FindObjectOfType<Tank>();

        // Zaktualizuj Slider na podstawie pocz�tkowego zdrowia czo�gu
        UpdateSlider(5);
    }

    public void UpdateSlider(int hp)
    {
        // Ustaw warto�� Slidera na podstawie aktualnego zdrowia czo�gu
        slider.value = hp;
    }
}
