using UnityEngine;

public class CarJump : MonoBehaviour
{
    public Transform car2; // Asigna car_2 desde el Inspector
    public float alturaSalto = 2f;
    public float duracionSalto = 0.5f;

    private bool saltando = false;
    private bool bajando = false;
    private float desplazamientoY = 0f;
    private Vector3 offsetInicial;

    void Start()
    {
        if (car2 != null)
            offsetInicial = car2.position - transform.position; // Offset global respecto al padre
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !saltando)
        {
            StartCoroutine(SaltoCar2());
        }
    }

    System.Collections.IEnumerator SaltoCar2()
    {
        saltando = true;
        float tiempo = 0f;

        // Subida
        bajando = false;
        while (tiempo < duracionSalto)
        {
            desplazamientoY = Mathf.Lerp(0, alturaSalto, tiempo / duracionSalto);
            ActualizarPosicionCar2();
            tiempo += Time.deltaTime;
            yield return null;
        }
        desplazamientoY = alturaSalto;
        ActualizarPosicionCar2();

        // Bajada
        tiempo = 0f;
        bajando = true;
        while (tiempo < duracionSalto)
        {
            desplazamientoY = Mathf.Lerp(alturaSalto, 0, tiempo / duracionSalto);
            ActualizarPosicionCar2();
            tiempo += Time.deltaTime;
            yield return null;
        }
        desplazamientoY = 0f;
        ActualizarPosicionCar2();

        MatarEnemigosCercanos(5.0f); // Puedes ajustar el radio

        bajando = false;
        saltando = false;
    }

    void ActualizarPosicionCar2()
    {
        if (car2 != null)
        {
            car2.position = transform.position + offsetInicial + transform.up * desplazamientoY;
        }
    }

    public bool IsBajando()
    {
        return bajando;
    }

    // Dentro de CarJump.cs
    public CocheController cocheController; // Asigna desde el Inspector

    void MatarEnemigosCercanos(float radio)
    {
        Collider[] colisiones = Physics.OverlapSphere(car2.position, radio);
        foreach (var col in colisiones)
        {
            if (col.CompareTag("Enemy"))
            {
                Destroy(col.gameObject);
                if (cocheController != null)
                {
                    cocheController.puntos++;
                    cocheController.ActualizarPuntosUI();
                }
            }

            if (col.CompareTag("enemy2"))
            {
                Enemy2Health enemy2Health = col.GetComponent<Enemy2Health>();
                if (enemy2Health != null)
                {
                    bool muerto = enemy2Health.TakeHit();
                    if (muerto && cocheController != null)
                    {
                        cocheController.puntos += 5;
                        cocheController.ActualizarPuntosUI();
                    }
                }
            }

            if (col.CompareTag("Enemy3"))
            {
                Enemy2Health enemy2Health = col.GetComponent<Enemy2Health>();
                if (enemy2Health != null)
                {
                    bool muerto = enemy2Health.TakeHit();
                    if (muerto && cocheController != null)
                    {
                        cocheController.puntos += 50;
                        cocheController.ActualizarPuntosUI();
                    }
                }
            }

        }
    }




    // Este método debe estar en un script que esté en car2 (o puedes reenviarlo desde otro script)
    private void OnTriggerEnter(Collider other)
    {
        if (bajando && other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            // Aquí puedes añadir feedback visual o sonoro por eliminar al enemigo
        }
    }
}
