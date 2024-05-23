using UnityEngine;

public class BulletSpawnPointGizmo : MonoBehaviour
{
    // Wy�wietla Gizmo w kszta�cie sfery na pozycji obiektu
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Kolor Gizmo
        Gizmos.DrawSphere(transform.position, 0.1f); // Rozmiar sfery
    }
}
