using UnityEngine;

public class Enemy3Shooter : MonoBehaviour
{
    public GameObject proyectilPrefab;      // Asigna el prefab del proyectil desde el Inspector
    public Transform puntoDisparo;          // Asigna un hijo vac�o en la parte frontal del enemigo
    public float velocidadProyectil = 20f;
    public float tiempoEntreDisparos = 2f;

    private float tiempoUltimoDisparo = 0f;
    private Transform objetivo;             // Referencia al coche

void Start()
    {
        // Solo disparar si el tag es Enemy3
        if (!CompareTag("Enemy3"))
        {
            enabled = false;
            return;
        }

        // Busca el objeto con el script CocheController
        var coche = FindFirstObjectByType<CocheController>();
        if (coche != null)
            objetivo = coche.transform;
    }

    void Update()
    {
        if (objetivo == null) return;

        if (Time.time - tiempoUltimoDisparo >= tiempoEntreDisparos)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

void Disparar()
{
    if (proyectilPrefab != null && puntoDisparo != null)
    {
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direccion = (objetivo.position - puntoDisparo.position).normalized;
            rb.linearVelocity = direccion * velocidadProyectil;
        }

        // Asigna el tipo y el dueño del proyectil
        Projectile script = proyectil.GetComponent<Projectile>();
        if (script != null)
        {
            script.tipo = Projectile.ProyectilTipo.Enemigo;
            script.owner = gameObject;
        }
    }
}

}
