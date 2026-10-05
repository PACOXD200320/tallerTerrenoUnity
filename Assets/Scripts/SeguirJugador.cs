using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset = new Vector3(0f, 25f, -35f);

    void LateUpdate()
    {
        if (jugador != null)
        {
            transform.position = jugador.position + offset;
            transform.LookAt(jugador);
        }
    }
}