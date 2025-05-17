using UnityEngine;

public class EnemyLevel2 : MonoBehaviour
{
    public float speed = 2f;
    public int health = 2;
    private bool movingRight = true;
    public Transform groundDetection;

    void Update()
    {
        // Movimiento igual que Enemy
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);
        if (groundInfo.collider == false)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    // Lógica para recibir daño (por ejemplo, al saltar sobre el enemigo)
    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Ejemplo de cómo detectar el salto del jugador (ajusta según tu lógica)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica si el jugador viene desde arriba
            if (collision.relativeVelocity.y > 0)
            {
                TakeDamage();
            }
        }
    }
}
