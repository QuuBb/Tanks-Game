using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    // Metoda do restartowania aktualnej sceny
    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Metoda do �adowania sceny menu
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("StartMenu"); // Upewnij si�, �e nazwa pasuje do nazwy twojej sceny menu
    }
}
