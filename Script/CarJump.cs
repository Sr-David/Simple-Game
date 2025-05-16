using UnityEngine;

public class CarJump : MonoBehaviour
{
    public Transform car2; // Asigna car_2 desde el Inspector
    public float alturaSalto = 2f;
    public float duracionSalto = 0.5f;

    private bool saltando = false;
    private float desplazamientoY = 0f;

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
        while (tiempo < duracionSalto)
        {
            desplazamientoY = Mathf.Lerp(alturaSalto, 0, tiempo / duracionSalto);
            ActualizarPosicionCar2();
            tiempo += Time.deltaTime;
            yield return null;
        }
        desplazamientoY = 0f;
        ActualizarPosicionCar2();

        saltando = false;
    }

    void ActualizarPosicionCar2()
    {
        if (car2 != null)
        {
            // Siempre se acopla a la posición actual de las ruedas (padre)
            car2.position = transform.position + Vector3.up * desplazamientoY;
            car2.rotation = transform.rotation; // Opcional: mantener la rotación igual al padre
        }
    }
}

