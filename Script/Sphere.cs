using UnityEngine;

public class EsferaMovimiento : MonoBehaviour
{
    public Vector3 puntoA = new Vector3(-5, 1, 0); // Posición inicial
    public Vector3 puntoB = new Vector3(5, 1, 0);  // Posición final
    public float velocidad = 2f;

    private float t = 0f;

    void Update()
    {
        // Calcula el valor t usando PingPong para ir de 0 a 1 y volver
        t = Mathf.PingPong(Time.time * velocidad, 1f);
        // Interpola la posición entre los dos puntos
        transform.position = Vector3.Lerp(puntoA, puntoB, t);
    }
}
