using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class CocheController : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento
    public float turnSpeed = 50f; // Velocidad de giro

    private float horizontalInput;
    private float verticalInput;

    private Rigidbody rb;

    void Start()
    {
        // Obtener el Rigidbody y asegurarse de que use gravedad
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // Mejorar detección de colisiones
    }

    void FixedUpdate()
    {
        // Capturar la entrada del jugador
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Mover el coche usando físicas
        Vector3 moveDirection = transform.forward * verticalInput * speed;
        rb.MovePosition(rb.position + moveDirection * Time.fixedDeltaTime);

        // Rotar el coche
        Quaternion turnRotation = Quaternion.Euler(0f, horizontalInput * turnSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
