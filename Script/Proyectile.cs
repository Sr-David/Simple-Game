using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float tiempoVida = 3f;
    public CocheController cocheController; // Añadido
    public enum ProyectilTipo { Jugador, Enemigo }
    public ProyectilTipo tipo = ProyectilTipo.Jugador;
    public GameObject owner; // Referencia al objeto que dispara


    private void Start()
    {
        Destroy(gameObject, tiempoVida);
        if (cocheController == null)
            cocheController = FindAnyObjectByType<CocheController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ignora la colisión con el dueño del proyectil
        if (owner != null && other.gameObject == owner)
            return;

        if (tipo == ProyectilTipo.Jugador)
        {
            Enemy2Health enemyHealth = other.GetComponent<Enemy2Health>();
            if (enemyHealth != null)
            {
                string tag = other.tag;
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
        else if (tipo == ProyectilTipo.Enemigo)
        {
            // Daño al jugador
            CocheController coche = other.GetComponent<CocheController>();
            if (coche != null && !coche.gameEnded)
            {
                coche.vidas--;
                coche.ActualizarVidasUI();
                if (coche.vidas <= 0)
                {
                    coche.gameEnded = true;
                    if (coche.winTextObject != null)
                    {
                        coche.winTextObject.SetActive(true);
                        var text = coche.winTextObject.GetComponent<TMPro.TextMeshProUGUI>();
                        if (text != null)
                            text.text = "Game Over!";
                    }
                }
                Destroy(gameObject);
                return;
            }
        }
    }



    private void SumarPuntosPorTag(string tag)
    {
        if (cocheController == null) return;

        if (tag == "Enemy")
        {
            cocheController.puntos+=10;
        }
        else if (tag == "enemy2")
        {
            cocheController.puntos += 20;
        }
        else if (tag == "Enemy3")
        {
            cocheController.puntos += 50;
        }
        cocheController.ActualizarPuntosUI();
    }
}
