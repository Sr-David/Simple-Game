using UnityEngine;

public class Car2EnemyKiller : MonoBehaviour
{
    public CarJump carJump; // Asigna el script CarJump desde el Inspector o por código

    private void OnTriggerEnter(Collider other)
    {
        if (carJump != null && carJump.IsBajando() && other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            // Aquí puedes añadir feedback visual o sonoro por eliminar al enemigo
        }
    }
}
