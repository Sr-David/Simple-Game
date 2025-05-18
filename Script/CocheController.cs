using UnityEngine;
using TMPro; // Necesario para TextMeshProUGUI

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class CocheController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;
    public int puntos = 0; // Puntos del usuario
    public TextMeshProUGUI puntosText; // Asigna el objeto de texto de puntos desde el Inspector


    public GameObject winTextObject; // Asigna el objeto de texto desde el Inspector
    public int vidas = 3; // Número de vidas inicial
    public TextMeshProUGUI vidasText; // Asigna el objeto de texto de vidas desde el Inspector

    private float horizontalInput;
    private float verticalInput;

    private Rigidbody rb;
    private bool gameEnded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        if (winTextObject != null)
            winTextObject.SetActive(false);

        // Oculta visual y colisión de los objetos "final" al inicio
        GameObject[] finales = GameObject.FindGameObjectsWithTag("final");
        foreach (var final in finales)
        {
            var renderer = final.GetComponent<Renderer>();
            if (renderer != null)
                renderer.enabled = false;
            var collider = final.GetComponent<Collider>();
            if (collider != null)
                collider.enabled = false;
        }

        ActualizarVidasUI();
        ActualizarPuntosUI();
    }



    void FixedUpdate()
    {
        if (gameEnded) return;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput * speed;
        rb.MovePosition(rb.position + moveDirection * Time.fixedDeltaTime);

        Quaternion turnRotation = Quaternion.Euler(0f, horizontalInput * turnSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("enemy2") || collision.gameObject.CompareTag("Enemy3")) && !gameEnded)
        {
            vidas--;
            ActualizarVidasUI();

            if (vidas <= 0)
            {
                gameEnded = true;
                if (winTextObject != null)
                {
                    winTextObject.SetActive(true);
                    var text = winTextObject.GetComponent<TextMeshProUGUI>();
                    if (text != null)
                        text.text = "You Lose!";
                }
                // gameObject.SetActive(false); // Opcional: desactiva el coche
            }
            // Aquí puedes añadir feedback visual o sonoro por perder una vida
        }


        if (collision.gameObject.CompareTag("final") && !gameEnded)
        {

            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";

            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            // Aquí puedes añadir feedback visual o sonoro por perder una vida
        }
    }


    public void ActualizarPuntosUI()
    {
        if (puntosText != null)
        {
            puntosText.text = "Puntos: " + puntos;
            if (puntos > 110)
            {
                GameObject[] finales = GameObject.FindGameObjectsWithTag("final");
                foreach (var final in finales)
                {
                    var renderer = final.GetComponent<Renderer>();
                    if (renderer != null)
                        renderer.enabled = true;
                    var collider = final.GetComponent<Collider>();
                    if (collider != null)
                        collider.enabled = true;
                }
            }
        }
    }






    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            vidas++;
            ActualizarVidasUI();
            Destroy(other.gameObject); // Elimina el pickup tras recogerlo
            // Aquí puedes añadir feedback visual o sonoro por recoger una vida
        }
    }

    private void ActualizarVidasUI()
    {
        if (vidasText != null)
        {
            vidasText.text = "Vidas: " + vidas;
        }
    }
}
