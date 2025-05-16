using UnityEngine;

public class Car2EnemyKiller : MonoBehaviour
{
    public CarJump carJump; // Asigna el script CarJump desde el Inspector o por c�digo

    private void OnTriggerEnter(Collider other)
    {
        if (carJump != null && carJump.IsBajando() && other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            // Aqu� puedes a�adir feedback visual o sonoro por eliminar al enemigo
        }
    }
}
