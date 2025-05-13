using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // El objeto que la c�mara seguir�
    public Vector3 offset = new Vector3(0, 5, -10); // Desplazamiento ajustable desde el Inspector

    // LateUpdate se llama despu�s de que todos los objetos se hayan actualizado
    void LateUpdate()
    {
        // Calcular la posici�n de la c�mara en funci�n de la rotaci�n del coche
        Vector3 rotatedOffset = player.transform.rotation * offset;
        transform.position = player.transform.position + rotatedOffset;

        // Asegurarse de que la c�mara mire al jugador
        transform.LookAt(player.transform.position + Vector3.up * 1.5f); // Ajusta el punto de enfoque si es necesario
    }
}
