using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float moveForce = 30f;      // Força aplicada
    public float maxSpeed = 5f;        // Velocidade máxima no eixo X
    public float stopFriction = 0.9f;  // Fator de desaceleração (entre 0 e 1)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal"); // valor -1, 0 ou 1 para controle preciso

        Vector3 velocity = rb.velocity;

        // Se houver entrada
        if (inputX != 0)
        {
            // Se ainda não atingiu a velocidade máxima
            if (Mathf.Abs(velocity.x) < maxSpeed)
            {
                rb.AddForce(new Vector3(inputX * moveForce, 0f, 0f), ForceMode.Force);
            }
        }
        else
        {
            // Reduz lentamente a velocidade no eixo X para evitar deslizar
            velocity.x *= stopFriction;
            rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
        }

        // Limita a velocidade no eixo X (garantia extra)
        velocity = rb.velocity;
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
    }
}