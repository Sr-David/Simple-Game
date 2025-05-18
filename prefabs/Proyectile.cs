using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float tiempoVida = 3f;
    public CocheController cocheController; // Añadido

    private void Start()
    {
        Destroy(gameObject, tiempoVida);
        if (cocheController == null)
            cocheController = FindAnyObjectByType<CocheController>();

    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy2Health enemyHealth = other.GetComponent<Enemy2Health>();
        if (enemyHealth != null)
        {
            // Guarda el tag antes de destruir
            string tag = other.tag;
            // Mata al enemigo de un tiro
            while (!enemyHealth.TakeHit()) { }
            SumarPuntosPorTag(tag);
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Enemy"))
        {
            SumarPuntosPorTag("Enemy");
            Destroy(other.gameObject);
            Destroy(gameObject);
            return;
        }
    }

    private void SumarPuntosPorTag(string tag)
    {
        if (cocheController == null) return;

        if (tag == "Enemy")
        {
            cocheController.puntos++;
        }
        else if (tag == "enemy2")
        {
            cocheController.puntos += 5;
        }
        else if (tag == "Enemy3")
        {
            cocheController.puntos += 50;
        }
        cocheController.ActualizarPuntosUI();
    }
}
