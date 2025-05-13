using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // El objeto que la cámara seguirá
    public Vector3 offset = new Vector3(0, 5, -10); // Desplazamiento ajustable desde el Inspector

    // LateUpdate se llama después de que todos los objetos se hayan actualizado
    void LateUpdate()
    {
        // Calcular la posición de la cámara en función de la rotación del coche
        Vector3 rotatedOffset = player.transform.rotation * offset;
        transform.position = player.transform.position + rotatedOffset;

        // Asegurarse de que la cámara mire al jugador
        transform.LookAt(player.transform.position + Vector3.up * 1.5f); // Ajusta el punto de enfoque si es necesario
    }
}
