using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 12f;
    public float fuerzaSalto = 10f;

    private Rigidbody rb;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = -Input.GetAxis("Horizontal");
        float vertical = -Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(horizontal, 0f, vertical);

        Vector3 velocidadActual = rb.linearVelocity;

        rb.linearVelocity = new Vector3(
            movimiento.x * velocidad,
            velocidadActual.y,
            movimiento.z * velocidad
        );

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }

        if (!enSuelo)
        {
            rb.AddForce(Vector3.down * 15f, ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        enSuelo = true;
    }
}