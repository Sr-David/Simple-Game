using UnityEngine;

public class Car2EnemyKiller : MonoBehaviour
{
    public CarJump carJump; // Asigna el script CarJump desde el Inspector o por c�digo

    private void OnTriggerEnter(Collider other)
    {
        if (carJump != null && carJump.IsBajando())
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                // Aqu� puedes a�adir feedback visual o sonoro por eliminar al enemigo
            }
            else if (other.CompareTag("enemy2"))
            {
                Enemy2Health enemy2Health = other.GetComponent<Enemy2Health>();
                if (enemy2Health != null)
                {
                    enemy2Health.TakeHit();
                    // Aqu� puedes a�adir feedback visual o sonoro por golpear al enemy2
                }
            }
            else if (other.CompareTag("Enemy3"))
            {
                Enemy2Health enemy2Health = other.GetComponent<Enemy2Health>();
                if (enemy2Health != null)
                {
                    enemy2Health.TakeHit();
                    // Aqu� puedes a�adir feedback visual o sonoro por golpear al enemy2
                }
            }
        }
    }
}

    